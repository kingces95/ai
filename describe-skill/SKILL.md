---
name: ai-skill
description: Define, document, and compose small agent skills as dependency-aware repositories using a shared template and an acyclic composition model.
---

# Synopsis

Use this skill to create or revise a repository that represents one reusable agent capability. Keep the contract small, explicit, and composable.

# Skills

This is the foundational skill specification and has no dependencies.

# Contract

- Give the repository an `<actor>-<capability>` name using lowercase kebab-case.
- Include `Synopsis` and `Skills` sections.
- In `Skills`, link every direct dependency by repository name. Do not list transitive dependencies.
- Keep the dependency graph acyclic. Reachability, including identity, is the composition partial order.
- Treat skills as capability descriptions, never as standing authorization.
- State inputs, outputs, security boundaries, confirmation points, and observable completion conditions when they materially affect correct use.
- Put substantial conditional procedures in focused references rather than expanding the entrypoint indefinitely.

# Workflow

1. Start from [`templates/SKILL.md`](templates/SKILL.md).
2. Write a discriminating description that says when the skill applies.
3. Describe the outcome in `Synopsis`.
4. List direct dependencies in `Skills`.
5. Add only the constraints and workflow details that change execution decisions.
6. Verify links, dependency acyclicity, and the absence of unresolved template markers.

