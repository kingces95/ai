---
name: save-secret
description: Remember a secret available to the AI for later recall on the local machine without exposing it in conversation.
---

# Synopsis

Use this skill when the AI has access to a secret that should be remembered for later use on the local machine. The need may be explicit, or a higher-level orchestrator may discover it after assembling enough context.

# Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.

# Inputs

- A secret available to the local workflow.
- Enough context to recognize it later and understand its intended use.

# Outputs

- The AI remembers the secret locally and can recall it when authorized.
- The workflow knows whether saving succeeded.

# Boundaries

- Never expose the secret in conversation, logs, reports, or other model-visible output.
- Remember, use, replace, or forget the secret only with authority appropriate to the surrounding task.
- Treat remembered context as potentially sensitive too.

# Workflow

Recognize when a secret should persist beyond its immediate step, whether the need is explicit or discovered through orchestration. Remember it locally with enough context for later recall, and forget it when its purpose is complete.

Choose mechanics appropriate to the environment and surrounding workflow.

# Verification

- The AI can recall the secret locally for its intended use without asking the user to expose it again.
- Saving and recall do not reveal the secret in model-visible output.
