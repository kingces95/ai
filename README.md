# ai-skills

A composable collection of small agent skills grouped by environment. Repository-governance skills live beneath `meta`; machine-facing skills live beneath environments such as `desktop`. Every skill directory contains its own `SKILL.md`.

Browse the collection by [primary user story](USER-STORIES.md).

## Skills

### Meta

- [`describe-skill`](meta/describe-skill) — defines the shared schema and repository-wide conformance process.

### Desktop

- [`save-secret`](desktop/save-secret) — remembers a secret available to the AI for later recall on the local machine.
- [`accept-secret`](desktop/accept-secret) — presents a simple experience for accepting a copied secret and remembering it for later use.
- [`create-secret`](desktop/create-secret) — creates and remembers credentials during authorized provisioning flows and produces a password-manager import.
- [`install-tailscale`](desktop/install-tailscale) — installs and enrolls a desktop with a one-off auth key, then returns the administrator's Machines link and non-secret device status.

## Naming

Drop repository-level actor prefixes from skill names. Prefer one clear lowercase word; when one word would be vague, use a short imperative verb–noun name such as `create-secret`. The directory name and the `name` in `SKILL.md` must match.

## Composition

The `Skills` section of each `SKILL.md` lists only its direct dependencies as relative links to their skill directories. Those edges must remain acyclic. Skills describe capabilities; dependency composition never grants authorization.

