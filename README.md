# ai

A compact library of composable AI skills. Each skill is a Markdown file in [`skills`](skills) with two top-level sections: `Prompt` for the intended human outcome and `Response` for the AI-generated elaboration.

GitHub is the public source of truth; CLOUD is the internal collaboration origin and distribution cache. Published versions are authenticated by signed Git tags. See the [trust and branch policy](TRUST.md) and [publication-key policy](KEYS.md) before treating repository content as policy.

## Skills

- [`describe-skill`](skills/describe-skill.md) — defines the prompt/response schema and repository-wide conformance process.
- [`crud-secret`](skills/crud-secret.md) — creates, recalls, updates, and deletes secrets in an encrypted local text vault without exposing plaintext to the agent.
- [`install-tailscale`](skills/install-tailscale.md) — installs and enrolls a machine with a one-time key, guides administrator approval, and forgets the key afterward.

## Naming

Use concise lowercase kebab-case filenames that help a model discover each capability. No grammatical naming pattern or repository-level actor prefix is required.

## Composition

Responses link direct dependencies by sibling Markdown filename. Those edges must remain acyclic. Skill composition never grants authorization.
