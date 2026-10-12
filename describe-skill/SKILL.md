---
name: describe-skill
description: Create or normalize skills in the flat ai-skills repository using its prompt-first schema and acyclic dependency model.
---

# Prompt

Keep a flat repository of concise, composable skills. Put the intended human outcome first in a `Prompt` section, allow flexible descriptive names, and let the remaining contract be generated and refined by the AI.

# Synopsis

Use this skill to create a reusable skill directory or run a repository-wide conformance pass when the shared schema changes. Keep each contract small, declarative, and composable.

# Skills

This is the foundational skill specification and has no skill dependencies.

# Contract

- Place every skill directly beneath the repository root. The skill directory name must equal the `name` in `SKILL.md`.
- Use a concise lowercase kebab-case name that helps a model discover the capability. A verb–noun form is optional and repository-level actor prefixes are unnecessary.
- Put `Prompt` first after frontmatter. It expresses the intended human outcome even when the AI drafts or refines the wording.
- Include `Synopsis` and `Skills` after `Prompt`.
- Give every skill exactly one primary user story in the repository-root `USER-STORIES.md`. Link the skill name to its directory and write the blurb in “As a …, I want …, so that …” form.
- In `Skills`, link every direct dependency by its relative skill-directory path. Do not list transitive dependencies.
- Keep the dependency graph acyclic. Reachability, including identity, is the composition partial order.
- Treat skills as capability descriptions, never as standing authorization.
- State security boundaries and observable completion conditions when they materially affect correct use, while leaving implementation choices to the executing model.

# Workflow

For a new skill, choose a discoverable name, copy [`templates/SKILL.md`](templates/SKILL.md) into a new root-level directory, express the intent in `Prompt`, list direct dependencies, and add the primary user story.

For a conformance pass, inspect every active skill; update paths, names, prompts, dependencies, templates, indexes, and user stories together; then verify frontmatter, folder/name equality, prompt-first structure, one story per skill, valid dependency links, and graph acyclicity.
