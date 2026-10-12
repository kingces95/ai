# ai-secrets

## Synopsis

Defines a temporary, machine-local provisioning vault for credentials generated while creating accounts on ordinary websites. Credentials remain encrypted at rest until the user requests a short-lived LastPass-compatible CSV export, verifies the import, and explicitly authorizes cleanup.

The password-manager import itself remains a human action.

## Skills

- [ai-skill](../ai-skill) — skill description and composition contract.

## Security model

- Generate passwords with a cryptographically secure random source and never place them in logs, reports, prompts, or command arguments.
- Encrypt records with a random data-encryption key. Protect that key with Windows DPAPI and, when explicitly implemented and verified, a TPM-sealed protector.
- Store only non-secret indexing metadata in plaintext.
- Treat account submission as a user-confirmed operation and verify successful creation before recording completion.
- Export plaintext CSV only when the user is ready to import it. Restrict access, minimize its lifetime, and never print its contents.
- Do not automate, inspect, or modify password-manager applications or websites. The user performs the import and confirms success.
- Purge the export, encrypted records, and key material only after explicit user confirmation. Explain that file deletion cannot guarantee physical overwrite on SSD storage.

