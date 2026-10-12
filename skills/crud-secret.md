# Prompt

Create a password vault on the local machine using available tooling to encrypt and decrypt passwords in memory without exposing them to the agent. Persist encrypted secrets in `SECRETS.txt` on the desktop using the simplest practical text format, such as key/value fields with records separated by newlines. Accept secrets from and return secrets to the user through the clipboard so plaintext secrets are neither seen by the agent nor persisted on disk.

# Response

## Dependencies

- [describe-skill](describe-skill.md) defines the repository schema.

## Capability

Create, accept, recall, update, and delete secrets for local workflows. The need may be explicit, or an orchestrator may select this skill after assembling enough context to recognize that a secret should be remembered or recalled.

Maintain `SECRETS.txt` on the desktop as a straightforward text vault containing ciphertext and useful identifying metadata. Use the simplest encryption, key protection, file format, secure-memory, and clipboard tooling appropriate to the machine.

## Experience

The AI may present controls such as **Accept copied secret**, **Copy secret**, **Update from clipboard**, and **Forget secret**. Plaintext enters from or returns to the clipboard; ordinary responses contain only non-secret status.

## Constraints

- Never expose plaintext secrets in conversation, logs, reports, command arguments, or other model-visible output.
- Never persist plaintext secrets on disk. The vault file alone must not disclose secret values.
- Keep generation, encryption, decryption, and clipboard transfer within trusted local tooling and memory.
- Apply authorization appropriate to each operation, especially recall, replacement, and deletion.

## Secure-memory illustration

This C# fragment is illustrative only. It demonstrates a bounded unmanaged-memory lifetime and explicit zeroing, not a prescribed vault implementation.

```csharp
using System.Runtime.InteropServices;
using System.Security.Cryptography;

sealed class SensitiveBuffer : IDisposable
{
    private IntPtr pointer;
    private readonly int length;

    public unsafe SensitiveBuffer(ReadOnlySpan<char> value)
    {
        length = checked(value.Length * sizeof(char));
        pointer = Marshal.AllocHGlobal(length);
        fixed (char* source = value)
            Buffer.MemoryCopy(source, (void*)pointer, length, length);
    }

    public void Use(Action<IntPtr, int> consumer) => consumer(pointer, length);

    public unsafe void Dispose()
    {
        if (pointer == IntPtr.Zero) return;
        CryptographicOperations.ZeroMemory(new Span<byte>((void*)pointer, length));
        Marshal.FreeHGlobal(pointer);
        pointer = IntPtr.Zero;
    }
}
```

## Completion

Authorized CRUD operations work across local workflow steps; recalled values arrive on the clipboard; and no plaintext secret appears in model-visible output or persistent files.
