// Illustrative only: this demonstrates bounded unmanaged-memory lifetime and
// zeroing. It does not prescribe clipboard, storage, discovery, or purge logic.

using System.Runtime.InteropServices;
using System.Security.Cryptography;

Span<char> source = stackalloc char[] { 'd', 'e', 'm', 'o' };

try
{
    using var secret = SensitiveBuffer.CopyUtf16(source);
    secret.Use(static (pointer, byteCount) =>
    {
        // A trusted native operation could consume the pointer here without
        // converting the secret into a managed string or printing it.
        _ = pointer;
        _ = byteCount;
    });
}
finally
{
    CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(source));
}

internal sealed class SensitiveBuffer : IDisposable
{
    private IntPtr _pointer;

    private SensitiveBuffer(IntPtr pointer, int byteCount)
    {
        _pointer = pointer;
        ByteCount = byteCount;
    }

    public int ByteCount { get; }

    public static unsafe SensitiveBuffer CopyUtf16(ReadOnlySpan<char> value)
    {
        var byteCount = checked(value.Length * sizeof(char));
        var destination = Marshal.AllocHGlobal(byteCount);

        fixed (char* source = value)
        {
            Buffer.MemoryCopy(source, (void*)destination, byteCount, byteCount);
        }

        return new SensitiveBuffer(destination, byteCount);
    }

    public void Use(Action<IntPtr, int> consumer)
    {
        ObjectDisposedException.ThrowIf(_pointer == IntPtr.Zero, this);
        consumer(_pointer, ByteCount);
    }

    public unsafe void Dispose()
    {
        if (_pointer == IntPtr.Zero)
        {
            return;
        }

        CryptographicOperations.ZeroMemory(new Span<byte>((void*)_pointer, ByteCount));
        Marshal.FreeHGlobal(_pointer);
        _pointer = IntPtr.Zero;
    }
}
