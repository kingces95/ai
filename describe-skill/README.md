# describe-skill

## Synopsis

Defines the common shape, vocabulary, naming rules, and composition model for skill directories in the `ai-skills` repository. A skill describes a reusable capability; it does not grant permission to perform that capability.

Use [`templates/SKILL.md`](templates/SKILL.md) when starting another skill directory.

## Skills

This is the foundational skill specification and has no skill dependencies.

## Composition model

Each immediate child directory of `ai-skills` is a node in a directed acyclic dependency graph. An entry in a skill's **Skills** section means that skill directly depends on the referenced sibling. Reachability, including identity, defines the partial order used to build meta-skills, provisioning flows, and applications.

Dependency composition never composes authorization: every concrete operation still observes its own consent, safety, and confirmation requirements.

## Naming

Prefer one clear lowercase word. When that would be vague, use a short imperative verb–noun name in lowercase kebab-case, such as `create-secret`. Do not prefix individual skills with `ai-`; the `ai-skills` repository already supplies that namespace.

## Conformance passes

Run repository-wide passes whenever the schema evolves. A pass should inspect every immediate skill directory, update names, direct dependency links, and the root [`USER-STORIES.md`](../USER-STORIES.md) consistently, preserve skill-specific meaning and safety boundaries, validate the full dependency graph, and commit the migration as one coherent change.

