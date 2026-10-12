# Prompt

Maintain a compact repository named `ai` whose skills are Markdown files in a single `skills` directory. Give every skill exactly two top-level sections: `Prompt`, expressing the intended human outcome, and `Response`, containing the AI-generated elaboration.

# Response

## Structure

- Store each skill as `skills/<skill-name>.md`.
- Use the filename as the skill identity; no frontmatter or per-skill README is required.
- Allow concise lowercase kebab-case names without imposing a grammatical pattern.
- Keep `Prompt` and `Response` as the only level-one headings, in that order.

## Composition

Link direct dependencies from the response using sibling Markdown paths. Keep the dependency graph acyclic and leave transitive dependencies implicit.

The prompt represents human intent even when the AI drafts or refines it. The response is generated guidance: declarative where possible, specific only where safety or correctness requires it, and never standing authorization.

## Conformance

A schema change updates all affected skill files and the repository index together. Verify filenames, two-heading structure, dependency links, graph acyclicity, and the absence of stale files from earlier schemas.
