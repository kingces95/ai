---
name: ai-secrets
description: Stage credentials generated during ordinary website-account provisioning in a machine-local encrypted vault, then prepare a short-lived password-manager import and retire the staging data after user verification.
---

# Synopsis

Use this skill for provisioning flows that must generate credentials before the user has finished configuring their long-term password manager. Keep secrets encrypted locally, minimize exposure, and end with a user-controlled import and verified cleanup.

# Skills

- [ai-skill](../ai-skill) — skill description and composition contract.

# Inputs

- Account metadata needed by the target website.
- The user's approved password policy and target import format.
- Explicit confirmation at account-creation submission and destructive cleanup boundaries.

# Outputs

- Encrypted local credential records plus non-secret indexing metadata.
- A short-lived import artifact prepared only when the user is ready.
- A cleanup report containing identifiers and outcomes, never secret values.

# Boundaries

- Never treat this staging store as an autonomous or long-term agent-owned vault.
- Never display, log, summarize, or persist plaintext passwords outside the minimum in-memory operation and temporary import artifact.
- Do not automate password-manager apps or websites. Hand the import step to the user.
- A CSV import is plaintext. Limit its permissions and lifetime; do not claim deletion guarantees physical erasure on SSDs.
- Skills describe capabilities and do not grant authorization to create accounts, transmit credentials, or delete data.

# Workflow

1. Resolve the destination site's requirements and obtain any needed user choices.
2. Generate the credential in memory with a cryptographically secure source.
3. Protect the record with a random encryption key whose protector is bound to the intended Windows user; use TPM sealing only when the implementation can verify it.
4. Create the ordinary website account, pausing for confirmation at the submission boundary.
5. Record successful provisioning without exposing the secret.
6. When requested, produce the target password manager's current import format in a tightly restricted temporary location.
7. Ask the user to import and verify the entries manually.
8. After explicit confirmation, remove the temporary artifact and cryptographically retire the staging vault by destroying its protecting key, then report what was removed and the SSD-erasure limitation.

# Verification

- Every provisioned record has non-secret metadata and an encrypted payload.
- No secret appears in logs, source control, command history, or status output.
- The user confirms the destination import before cleanup.
- Cleanup leaves no usable staging key or expected plaintext export at its known path.

