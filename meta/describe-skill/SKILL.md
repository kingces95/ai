---
name: describe-skill
description: Create or normalize skill directories in the ai-skills repository using its meta schema, environment grouping, concise naming rules, and acyclic dependency model.
---

# Synopsis

Use this skill to create a reusable skill directory or run a repository-wide conformance pass when the shared schema changes. Keep each contract small, explicit, and composable.

# Skills

This is the foundational skill specification and has no skill dependencies.

# Contract

- Place repository-governance skills beneath `meta` and machine-facing skills beneath an execution environment such as `desktop`. The skill directory name must equal the `name` in `SKILL.md`.
- Prefer one clear lowercase word. Otherwise use a short imperative verb–noun name in lowercase kebab-case. Do not add an `ai-` prefix.
- Include `Synopsis` and `Skills` sections.
- Give every skill exactly one primary user story in the repository-root `USER-STORIES.md`. Link the skill name to its repository-relative directory and write the blurb in “As a …, I want …, so that …” form.
- In `Skills`, link every direct dependency by its relative skill-directory path. Do not list transitive dependencies.
- Keep the dependency graph acyclic. Reachability, including identity, is the composition partial order.
- Treat skills as capability descriptions, never as standing authorization.
- State inputs, outputs, security boundaries, confirmation points, and observable completion conditions when they materially affect correct use.
- Put substantial conditional procedures in focused references rather than expanding the entrypoint indefinitely.

# Workflow

For a new skill:

1. Choose the shortest clear name under the naming rule, select its environment (`meta` for repository governance or an execution environment such as `desktop`), and copy [`templates/SKILL.md`](templates/SKILL.md) into the target directory.
2. Write a discriminating description that says when the skill applies.
3. Describe the outcome in `Synopsis`, list direct dependencies in `Skills`, and add its primary story to the root `USER-STORIES.md`.
4. Add only the constraints and workflow details that change execution decisions.

For a conformance pass:

1. Discover and inspect every directory containing a `SKILL.md` before editing.
2. Apply the schema change consistently while preserving skill-specific intent, history, and safety boundaries.
3. Update all affected names, links, templates, the root user-story index, and other repository indexes together.
4. Verify frontmatter, folder/name equality, environment placement, one correctly linked primary story per skill, direct dependency links, graph acyclicity, and the absence of unresolved placeholders in active skills.
5. Commit the pass as one coherent repository change.

