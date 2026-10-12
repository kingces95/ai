# create-secret

## Synopsis

Creates secrets for authorized provisioning, remembers them locally for later use, and prepares a password-manager import when requested.

The password-manager import itself remains a human action.

## Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.
- [save-secret](../save-secret) — remembers each created secret for later local recall.

## Security model

- Generate passwords with a cryptographically secure random source and never place them in logs, reports, prompts, or command arguments.
- Remember created secrets through `save-secret` and keep them out of chat, logs, command output, and reports.
- Treat account submission as a user-confirmed operation and verify successful creation before recording completion.
- Export plaintext CSV only when the user is ready to import it. Restrict access, minimize its lifetime, and never print its contents.
- Do not automate, inspect, or modify password-manager applications or websites. The user performs the import and confirms success.
- Forget remembered credentials and remove the export only after explicit user confirmation. Explain that file deletion cannot guarantee physical overwrite on SSD storage.

## Acceptance criteria

- Every account created by the flow has a unique remembered credential.
- The flow can use a credential without exposing its plaintext to the model or ordinary telemetry.
- The final artifact conforms to the selected password manager's current import schema and includes every successfully provisioned credential selected by the user.
- The user receives a non-secret manifest showing what the artifact contains, where it was written, and which entries still need attention.
- Credentials remain available until the user verifies the import, and are forgotten only after explicit confirmation.

