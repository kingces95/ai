---
name: save-secret
description: Capture a user-supplied clipboard secret through an explicit local UX, store it in the operating system's private credential store, and return an opaque reference for later authorized use.
---

# Synopsis

Use this skill when the user has a secret that a later local workflow needs but the secret must not pass through model context. Provide a simple local experience that moves the user's clipboard value into a suitable private store and returns an opaque reference.

# Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.

# Inputs

- A user-supplied clipboard secret.
- Context from which to infer useful metadata and a later purpose.
- An explicit user action authorizing capture and storage.

# Outputs

- An opaque reference that a later authorized local consumer can resolve.
- Non-secret metadata and storage status.

# Boundaries

- Keep the clipboard value outside model context and ordinary tool output. Let a small local helper perform the secret-bearing work.
- Never intentionally print or log the secret, and avoid plaintext files or process arguments.
- Make capture an explicit user action. Retrieval, consumption, replacement, and deletion remain separately authorized operations.
- Treat inferred metadata as potentially sensitive and let the user correct it when useful.
- Clipboard clearing may be offered, but cannot retract clipboard history or synchronized copies.

# Workflow

Infer metadata from context, choose an appropriate private store for the environment, and provide a small capture UX. The implementation is intentionally left to the executing model; it may generate a helper, reuse a trustworthy local facility, or choose another design that preserves the boundary above.

On Windows, Credential Manager is one possible store. The [C# secure-memory example](examples/SecureMemoryExample) illustrates limiting copies and clearing unmanaged buffers; it is not a prescribed helper or complete storage implementation.

Return an opaque reference and enough non-secret status for the later workflow. Let that workflow determine how to discover, consume, and eventually retire the record safely in its own environment.

# Verification

- A later authorized consumer can resolve the opaque reference without the secret appearing in model-visible output.
- The capture result reports success or failure without revealing the clipboard value.
