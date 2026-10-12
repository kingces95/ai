---
name: ai-lastpass
description: Prepare a LastPass-compatible import from locally staged credentials and guide a human through manual import, verification, and subsequent staging cleanup.
---

# Synopsis

Use this skill at the password-manager handoff boundary of a provisioning flow. Prepare the import artifact without revealing its secret fields, then let the user operate LastPass and attest that the import succeeded.

# Skills

- [ai-skill](../ai-skill) — skill description and composition contract.
- [ai-secrets](../ai-secrets) — encrypted credential staging and retirement.

# Boundaries

- Do not automate, inspect, or modify the LastPass application or website.
- Obtain the current import schema from authoritative LastPass documentation at execution time rather than assuming a historical column layout.
- Never render secret fields in previews, validation output, logs, or reports.
- Do not remove the source vault or export until the user confirms the imported entries work.

# Workflow

1. Confirm which staged records the user wants included.
2. Resolve the current LastPass CSV schema and map only supported fields.
3. Generate the temporary CSV with restrictive local permissions and validate its structure without printing secret values.
4. Give the user the file location and concise manual import instructions.
5. Ask the user to verify representative entries in LastPass.
6. On explicit confirmation, invoke the cleanup lifecycle defined by `ai-secrets`.

# Verification

- The CSV conforms to the current documented LastPass schema.
- Validation reports counts and identifiers only, never passwords or secure-note contents.
- The user confirms import success before cleanup begins.

