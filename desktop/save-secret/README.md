# save-secret

## Synopsis

Remembers a secret available to the AI for later recall on the local machine without exposing it in conversation.

The skill can be selected explicitly or discovered by an orchestrator once enough context has been assembled to know that a secret should persist.

## Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.

## Outcome

The AI remembers the secret with useful context, can recall it later when authorized, and forgets it when its purpose is complete. Implementation details belong to the execution environment.
