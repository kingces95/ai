# ai-skills

A composable collection of small agent skills. Each immediate child directory is one skill and contains its own `SKILL.md`.

Browse the collection by [primary user story](USER-STORIES.md).

## Skills

- [`describe-skill`](describe-skill) — defines the shared schema and repository-wide conformance process.
- [`create-secret`](create-secret) — stages credentials generated during authorized provisioning flows and produces a password-manager import.

## Naming

Drop repository-level actor prefixes from skill names. Prefer one clear lowercase word; when one word would be vague, use a short imperative verb–noun name such as `create-secret`. The directory name and the `name` in `SKILL.md` must match.

## Composition

The `Skills` section of each `SKILL.md` lists only its direct dependencies as relative links to sibling directories. Those edges must remain acyclic. Skills describe capabilities; dependency composition never grants authorization.

