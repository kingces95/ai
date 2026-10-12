# save-secret

## Synopsis

Captures a user-supplied secret from the clipboard through an explicit local action, stores it in the operating system's private credential store, and gives later provisioning steps an opaque reference instead of the value.

The AI supplies and reviews contextual metadata. A separate local helper performs the secret-bearing operation, so the clipboard value never enters chat, prompts, command arguments, logs, or ordinary tool output.

## Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.

## Client experience

1. The AI presents inferred service, account, and purpose metadata.
2. The user copies the secret and selects **Capture clipboard and save**.
3. A local helper stores it in an appropriate private store and may offer to clear the clipboard.
4. The AI receives an opaque reference and non-secret status for later authorized use.

Clearing the current clipboard cannot retract data already retained by clipboard history, synchronized devices, or other software.

## Windows illustration

[`examples/SecureMemoryExample`](examples/SecureMemoryExample) is a deliberately narrow C# illustration of copying sensitive characters into unmanaged memory, allowing a consumer to use the pointer, and zeroing both source and unmanaged buffers afterward.

It is not a clipboard reader, credential-store client, or mandated implementation. An AI is expected to devise the helper, storage, discovery, and retirement mechanics appropriate to its environment while preserving the client experience and security boundary.
