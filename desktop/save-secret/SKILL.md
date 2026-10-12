---
name: save-secret
description: Securely remember a secret copied by the user so the AI can use it later without exposing it in conversation.
---

# Synopsis

Use this skill when the user wants the AI to remember a copied secret for later use. Keep the secret out of conversation while retaining enough context to use and eventually forget it appropriately.

# Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.

# Inputs

- A secret copied by the user.
- The surrounding context and intended later use.
- The user's explicit action to save it.

# Outputs

- The AI remembers the secret and can use it later for the intended purpose.
- The user knows whether saving succeeded.

# Boundaries

- Never expose the secret in conversation, logs, reports, or other model-visible output.
- Saving, using, replacing, and forgetting a secret require the authority appropriate to those actions.
- Treat remembered context as potentially sensitive too.

# Workflow

Give the user a clear way to save the secret they copied. Remember it securely with useful context, use it later when authorized, and forget it when its purpose is complete.

Choose implementation details that fit the environment. On Windows, Credential Manager may be useful. The [C# secure-memory example](examples/SecureMemoryExample) only illustrates limiting copies and clearing unmanaged buffers; it does not prescribe the solution.

# Verification

- The AI can use the remembered secret later without asking the user to expose it again.
- Saving and later use do not reveal the secret in model-visible output.
