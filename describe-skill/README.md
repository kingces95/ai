# ai-skill

## Synopsis

Defines the common shape, vocabulary, and composition rules for small agent-skill repositories. A skill describes a reusable capability; it does not grant permission to perform that capability.

Use [`templates/SKILL.md`](templates/SKILL.md) when starting another skill repository.

## Skills

This is the foundational skill specification and has no dependencies.

## Composition model

Each repository is a node in a directed acyclic dependency graph. An entry in a repository's **Skills** section means that repository depends on the referenced skill. Reachability, including identity, defines the partial order used to build meta-skills, provisioning flows, and applications.

Dependency composition never composes authorization: every concrete operation still observes its own consent, safety, and confirmation requirements.

## Naming

Use `<actor>-<capability>`, where the actor identifies the intended execution role—for example `ai-`, `muse-`, or `codex-`—and the capability is lowercase kebab-case.

