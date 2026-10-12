---
name: accept-secret
description: Present a simple experience for accepting a secret copied by the user and remember it for later authorized use.
---

# Synopsis

Use this skill when the user needs to give the AI a secret without exposing it in conversation. Present a simple capture experience, accept the copied secret, and remember it through `save-secret`.

# Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.
- [save-secret](../save-secret) — remember the accepted secret for later local recall.

# Inputs

- A secret copied by the user.
- The surrounding context and intended later use.
- The user's explicit action to accept it.

# Outputs

- The AI remembers the accepted secret for the intended purpose.
- The user knows whether acceptance succeeded.

# Boundaries

- Never expose the secret in conversation, logs, reports, or other model-visible output.
- Make acceptance an explicit user action and treat inferred context as potentially sensitive.

# Workflow

When the workflow needs a user-held secret, invite the user to copy it and present a simple experience such as an **Accept copied secret** button. Accept it when the user activates the experience, then use `save-secret` to remember it with useful context.

Choose implementation details that fit the environment. The [C# secure-memory example](examples/SecureMemoryExample) only illustrates limiting copies and clearing unmanaged buffers; it does not prescribe the solution.

# Verification

- The AI can use the accepted secret later without asking the user to expose it again.
- Acceptance does not reveal the secret in model-visible output.
