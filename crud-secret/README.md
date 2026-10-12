# crud-secret

## Prompt

Create a simple encrypted password vault in `SECRETS.txt` on the desktop. Encrypt and decrypt secrets in local memory, and exchange plaintext with the user through the clipboard without exposing it to the agent or persisting it on disk.

## Synopsis

Creates, accepts, recalls, updates, and deletes secrets for local workflows. The skill may be requested directly or discovered by an orchestrator once enough context exists to recognize the need.

## Skills

- [describe-skill](../describe-skill) — skill description and composition contract.

## Client experience

- The AI can present controls such as **Accept copied secret**, **Copy secret**, **Update from clipboard**, and **Forget secret**.
- `SECRETS.txt` is a simple text vault containing encrypted records and useful metadata, never plaintext secret values.
- The executing AI chooses appropriate local encryption, key protection, memory handling, and clipboard tooling.

## Illustration

[`examples/SecureMemoryExample`](examples/SecureMemoryExample) demonstrates bounded unmanaged-memory lifetime and zeroing. It deliberately does not prescribe the vault implementation.
