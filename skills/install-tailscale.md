# Prompt

Install Tailscale on this machine and join it to the intended network using a one-time secret. If administrator approval is required, provide the administrator link and a simple way to learn when approval is complete. Forget the one-time secret after the machine has joined successfully.

# Response

## Dependencies

- [crud-secret](crud-secret.md) manages the one-time key without exposing it.

## Capability

Install Tailscale if needed, recall the key through `crud-secret`, and enroll the machine. Report whether it connected, needs administrator approval, or remains unresolved.

When approval is useful, provide the Tailscale Machines page at `https://login.tailscale.com/admin/machines` and a suitable completion experience. Opening the link alone is not proof that approval finished. After successful enrollment, delete the one-time key through `crud-secret`.

## Constraints

- Never expose the auth key in conversation, logs, reports, command arguments, or other model-visible output.
- Treat a one-time key as consumable and preserve uncertainty instead of retrying it blindly.
- Do not disturb an existing working connection or change tailnet policy without separate authority.

## Completion

Tailscale reports the machine connected, awaiting approval, or unresolved; the administrator can identify it from the information provided; and the one-time key is forgotten after successful enrollment.
