# accept-secret

## Synopsis

Presents a simple experience for accepting a secret copied by the user and remembers it for later authorized use.

## Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.
- [save-secret](../save-secret) — remembers the accepted secret for later local recall.

## Client experience

1. The AI presents inferred context and a clear control such as **Accept copied secret**.
2. The user copies the secret and activates the control while it is in the clipboard.
3. The AI remembers it securely for later authorized use.

## Illustration

[`examples/SecureMemoryExample`](examples/SecureMemoryExample) is a deliberately narrow C# illustration of copying sensitive characters into unmanaged memory, allowing a consumer to use the pointer, and zeroing both source and unmanaged buffers afterward.

It is not a clipboard reader or mandated implementation. The executing AI chooses mechanics appropriate to its environment while preserving the client experience and security boundary.
