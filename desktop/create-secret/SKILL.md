---
name: create-secret
description: Create secrets for authorized provisioning, remember them locally for later use, and produce a password-manager import when requested.
---

# Synopsis

Use this skill when an authorized workflow needs the AI to create secrets. Remember each secret through `save-secret`, use it for the intended provisioning, and prepare a password-manager import when requested.

# Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.
- [save-secret](../save-secret) — remember each created secret for later local recall.

# Inputs

- Account metadata needed by the target website.
- The target website's password requirements and the user's target password manager or import format.
- Explicit confirmation at account-creation submission and destructive cleanup boundaries.

# Outputs

- Created secrets remembered locally with useful context.
- A short-lived import artifact containing the credentials selected by the user, prepared only when the user is ready.
- A non-secret summary of completed, failed, and unresolved provisioning.

# Boundaries

- Never display, log, summarize, or place plaintext passwords in prompts, tool output, command arguments, source control, or reports.
- Do not automate password-manager apps or websites. Hand the import step to the user.
- A CSV import is plaintext. Limit its permissions and lifetime; do not claim deletion guarantees physical erasure on SSDs.
- Skills describe capabilities and do not grant authorization to create accounts, transmit credentials, or delete data.

# Workflow

Create suitable secrets for the authorized workflow and remember each one through `save-secret`. Use them where intended without exposing them in conversation, and track enough context to prepare the requested password-manager import.

After the user verifies the import, forget the remembered secrets when they are no longer needed and remove temporary export material. Choose generation, storage, export, and cleanup mechanics appropriate to the environment.

# Verification

- Every created secret can be recalled for its intended provisioning and export without appearing in model-visible output.
- The import artifact contains each selected successfully provisioned credential exactly once and conforms to the target manager's current schema.
- The user confirms the destination import before cleanup.
- The AI forgets secrets that are no longer needed and removes expected temporary export material.

