# install-tailscale

## Synopsis

Installs Tailscale on an authorized desktop, enrolls it with a supplied one-off auth key, and returns the administrator's Machines link with the device's non-secret status. The auth key stays outside model context and ordinary telemetry.

## Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.
- [save-secret](../save-secret) — remembers the one-time auth key for later use and forgets it when finished.

## Security model

- Use the one-time auth key remembered with `save-secret` without exposing it.
- Inject the key directly into the Tailscale enrollment process without placing it in prompts, command arguments, shell history, files, logs, or reports.
- Do not retry an uncertain enrollment blindly because a one-off key may already have been consumed.
- Do not infer administrator completion merely from opening the Machines link. Offer a suitable way to report or observe completion.
- Treat software installation and tailnet enrollment as explicit, user-authorized mutations.
- Leave auth-key creation, device approval, and tailnet policy changes to separately authorized administrator workflows.
- After completion is sufficiently established, forget the consumed key and report the outcome.

## Result

The caller receives the client and service state, the device's non-secret identity, and one of four enrollment results: already connected, connected, needs administrator approval, or failed/uncertain. The result includes the [Tailscale Machines page](https://login.tailscale.com/admin/machines) for administrator review or approval. When approval is needed, the local UX provides a way to learn that the administrator finished so the AI can forget the one-time key.

## References

- [Install Tailscale on Windows](https://tailscale.com/docs/install/windows)
- [Auth keys](https://tailscale.com/docs/features/access-control/auth-keys)
- [Secure auth-key usage](https://tailscale.com/docs/features/access-control/auth-keys/how-to/secure-auth-keys)
- [Device approval](https://tailscale.com/docs/features/access-control/device-management/device-approval)
