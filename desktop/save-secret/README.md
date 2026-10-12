# save-secret

## Synopsis

Securely remembers a secret copied by the user so the AI can use it later without exposing it in conversation.

The AI remembers the secret together with useful context, reports whether saving worked, and forgets it when its purpose is complete.

## Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.

## Client experience

1. The AI presents inferred context and a clear control such as **Remember copied secret**.
2. The user copies the secret and activates the control while it is in the clipboard.
3. The AI remembers it securely for later authorized use.
4. The AI forgets it when it is no longer needed.

Clearing the current clipboard cannot retract data already retained by clipboard history, synchronized devices, or other software.

## Windows illustration

[`examples/SecureMemoryExample`](examples/SecureMemoryExample) is a deliberately narrow C# illustration of copying sensitive characters into unmanaged memory, allowing a consumer to use the pointer, and zeroing both source and unmanaged buffers afterward.

It is not a clipboard reader, credential-store client, or mandated implementation. The executing AI chooses mechanics appropriate to its environment while preserving the client experience and security boundary.
