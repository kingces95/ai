# ai-skills

A composable collection of small agent skills. Cross-environment skills may live at the repository root; environment-specific skills live beneath directories such as `desktop`. Every skill directory contains its own `SKILL.md`.

Browse the collection by [primary user story](USER-STORIES.md).

## Skills

### Cross-environment

- [`describe-skill`](describe-skill) — defines the shared schema and repository-wide conformance process.

### Desktop

- [`create-secret`](desktop/create-secret) — stages credentials generated during authorized provisioning flows and produces a password-manager import.

## Naming

Drop repository-level actor prefixes from skill names. Prefer one clear lowercase word; when one word would be vague, use a short imperative verb–noun name such as `create-secret`. The directory name and the `name` in `SKILL.md` must match.

## Composition

The `Skills` section of each `SKILL.md` lists only its direct dependencies as relative links to their skill directories. Those edges must remain acyclic. Skills describe capabilities; dependency composition never grants authorization.

