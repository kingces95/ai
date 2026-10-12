# install-tailscale

## Prompt

Install Tailscale, join this machine with a one-time secret, guide any administrator approval, and forget the secret after successful enrollment.

## Synopsis

Installs and enrolls Tailscale without exposing the one-time key. When approval is needed, the client experience includes the [Tailscale Machines page](https://login.tailscale.com/admin/machines) and a way to report or observe completion.

## Skills

- [describe-skill](../describe-skill) — skill description and composition contract.
- [crud-secret](../crud-secret) — manages the one-time key through its local lifecycle.

## Result

The machine is connected, awaiting approval, or clearly unresolved. After successful enrollment, the one-time key is removed from the local vault.

## References

- [Install Tailscale on Windows](https://tailscale.com/docs/install/windows)
- [Auth keys](https://tailscale.com/docs/features/access-control/auth-keys)
- [Secure auth-key usage](https://tailscale.com/docs/features/access-control/auth-keys/how-to/secure-auth-keys)
- [Device approval](https://tailscale.com/docs/features/access-control/device-management/device-approval)
