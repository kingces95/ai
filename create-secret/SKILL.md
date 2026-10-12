---
name: ai-secrets
description: Perform authorized provisioning flows with agent-generated credentials kept outside model context, then deliver a short-lived password-manager import and retire staging data after user verification.
---

# Synopsis

Use this skill when a user wants an AI to complete an authorized provisioning flow, create the passwords required by that flow, and deliver the resulting credentials in a format their password manager can import. Keep secrets outside model context and encrypted locally, then end with a user-controlled import and verified cleanup.

# Skills

- [ai-skill](../ai-skill) — skill description and composition contract.

# Inputs

- Account metadata needed by the target website.
- The target website's password requirements and the user's target password manager or import format.
- Explicit confirmation at account-creation submission and destructive cleanup boundaries.

# Outputs

- Encrypted local credential records plus non-secret indexing metadata.
- A short-lived import artifact containing the credentials selected by the user, prepared only when the user is ready.
- A non-secret manifest of included, excluded, failed, and unresolved provisioning records.
- A cleanup report containing identifiers and outcomes, never secret values.

# Boundaries

- Never treat this staging store as an autonomous or long-term agent-owned vault.
- Keep plaintext passwords outside model context. A trusted helper may hold them only for the minimum in-memory operation, encrypted storage, authorized consumer handoff, and temporary import artifact.
- Expose secret operations through opaque record identifiers. Return status and policy results rather than secret values.
- Never display, log, summarize, or place plaintext passwords in prompts, tool output, command arguments, source control, or reports.
- Do not automate password-manager apps or websites. Hand the import step to the user.
- A CSV import is plaintext. Limit its permissions and lifetime; do not claim deletion guarantees physical erasure on SSDs.
- Skills describe capabilities and do not grant authorization to create accounts, transmit credentials, or delete data.

# Workflow

1. Resolve the destination site's requirements and obtain any needed user choices.
2. Ask a trusted local helper to generate the credential with a cryptographically secure source and return only an opaque record ID plus policy results.
3. Protect the record with a random encryption key whose protector is bound to the intended operating-system user. Use hardware-backed key protection only when the implementation can verify it.
4. Provide the credential to the authorized account-creation consumer by secret reference, without routing plaintext through the model, and pause for confirmation at the submission boundary.
5. Record successful provisioning, failure, or uncertainty against the opaque record ID without exposing the secret.
6. When requested, resolve the target password manager's current import schema and produce the import artifact in a tightly restricted temporary location.
7. Present the artifact location and a non-secret manifest, then ask the user to import and verify the entries manually.
8. After explicit confirmation, remove the temporary artifact and cryptographically retire the staging vault by destroying its protecting key, then report what was removed and the SSD-erasure limitation.

# Verification

- Every provisioned record has non-secret metadata and an encrypted payload.
- No secret appears in model context, logs, source control, command history, status output, or the non-secret manifest.
- The import artifact contains each selected successfully provisioned credential exactly once and conforms to the target manager's current schema.
- The user confirms the destination import before cleanup.
- Cleanup leaves no usable staging key or expected plaintext export at its known path.

