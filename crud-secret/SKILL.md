---
name: crud-secret
description: Create, recall, update, and delete secrets in an encrypted local vault while exchanging plaintext only through protected memory and the clipboard.
---

# Prompt

Create a password vault on the local machine using available tooling to encrypt and decrypt passwords in memory without exposing them to the agent. Persist encrypted secrets in `SECRETS.txt` on the desktop using the simplest practical text format. Accept secrets from and return secrets to the user through the clipboard so plaintext is neither shown to the agent nor persisted on disk.

# Synopsis

Use this skill whenever a workflow needs to create, accept, recall, update, or delete a secret on the local machine. The request may be explicit, or an orchestrator may select the skill after assembling enough context to recognize that a secret must be remembered or recalled.

# Skills

- [describe-skill](../describe-skill) — skill description and composition contract.

# Inputs

- The requested secret operation and enough context to identify the record.
- For accepted or updated values, a secret copied by the user.
- Authorization appropriate to creating, recalling, changing, or deleting the record.

# Outputs

- An updated encrypted `SECRETS.txt` on the desktop for create, accept, update, or delete operations.
- The requested secret placed on the clipboard for recall.
- Non-secret status describing the result.

# Boundaries

- Never expose plaintext secrets in conversation, logs, reports, command arguments, or other model-visible output.
- Never persist plaintext secrets on disk. `SECRETS.txt` contains ciphertext and only the metadata needed to identify records.
- Keep encryption, decryption, generation, and clipboard transfer within trusted local tooling and memory.
- Apply the authorization appropriate to each operation, especially recall, replacement, and deletion.

# Workflow

Use the simplest tooling available in the environment to maintain `SECRETS.txt` on the desktop. Keep its format straightforward, such as key/value fields with records separated by newlines, while ensuring the file alone does not disclose secret values.

Generate secrets or accept them from the clipboard, remember them with useful context, return recalled values through the clipboard, update records when asked, and delete records when they are no longer needed. Choose the concrete encryption, key protection, file format, secure-memory, and clipboard mechanics that best fit the machine.

The [C# secure-memory example](examples/SecureMemoryExample) illustrates limiting copies and clearing unmanaged buffers. It is not a prescribed vault implementation.

# Verification

- Authorized create, recall, update, and delete operations work across local workflow steps.
- Plaintext secrets appear only in protected local memory or the clipboard and never in model-visible output or persistent files.
- `SECRETS.txt` remains usable by the local workflow while disclosing no secret value without the machine's decryption capability.
