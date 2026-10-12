# ai-skills

A flat collection of small, composable agent skills. Every root-level skill directory contains a `SKILL.md` whose first section, `Prompt`, states the intended human outcome; the remaining contract is generated and refined for AI execution.

Browse the collection by [primary user story](USER-STORIES.md).

## Skills

- [`describe-skill`](describe-skill) — defines the prompt-first schema and repository-wide conformance process.
- [`crud-secret`](crud-secret) — creates, recalls, updates, and deletes secrets in an encrypted local text vault without exposing plaintext to the agent.
- [`install-tailscale`](install-tailscale) — installs and enrolls a machine with a one-time key, guides administrator approval, and forgets the key afterward.

## Naming

Use concise lowercase kebab-case names that help a model discover the capability. Verb–noun names are optional; repository-level actor prefixes are unnecessary. The directory name and the `name` in `SKILL.md` must match.

## Composition

The `Skills` section of each `SKILL.md` lists only its direct dependencies as relative links to sibling skill directories. Those edges must remain acyclic. Skills describe capabilities; dependency composition never grants authorization.
