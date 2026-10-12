# ai-secrets

## Synopsis

Defines a temporary, machine-local provisioning vault for credentials generated while creating accounts on ordinary websites. Credentials remain encrypted at rest until the user requests a short-lived password-manager import, verifies the import, and explicitly authorizes cleanup.

The password-manager import itself remains a human action.

## Primary user story

> As a user, I want my AI to perform an authorized provisioning flow and create the passwords it needs, so that at the end it can give me those credentials in a format I can import into my password manager.

“Give me” means producing a protected, short-lived import artifact and its non-secret summary. It does not mean printing passwords into chat, logs, command output, or reports.

## Skills

- [ai-skill](../ai-skill) — skill description and composition contract.

## Security model

- Generate passwords with a cryptographically secure random source and never place them in logs, reports, prompts, or command arguments.
- Keep plaintext out of the model context. The agent reasons over opaque credential identifiers, policy results, metadata, and lifecycle state; a trusted helper performs generation, storage, retrieval for an authorized consumer, export, and destruction.
- Encrypt records with a random data-encryption key. Protect that key with Windows DPAPI and, when explicitly implemented and verified, a TPM-sealed protector.
- Store only non-secret indexing metadata in plaintext.
- Treat account submission as a user-confirmed operation and verify successful creation before recording completion.
- Export plaintext CSV only when the user is ready to import it. Restrict access, minimize its lifetime, and never print its contents.
- Do not automate, inspect, or modify password-manager applications or websites. The user performs the import and confirms success.
- Purge the export, encrypted records, and key material only after explicit user confirmation. Explain that file deletion cannot guarantee physical overwrite on SSD storage.

## Acceptance criteria

- Every account created by the flow has a unique generated credential associated with an opaque record ID.
- The flow can use a credential without exposing its plaintext to the model or ordinary telemetry.
- The final artifact conforms to the selected password manager's current import schema and includes every successfully provisioned credential selected by the user.
- The user receives a non-secret manifest showing what the artifact contains, where it was written, and which entries still need attention.
- Staging data remains recoverable until the user verifies the import, and cleanup occurs only after explicit confirmation.

