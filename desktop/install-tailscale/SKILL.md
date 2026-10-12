---
name: install-tailscale
description: Install Tailscale on a desktop, consume a supplied one-off auth key without exposing it, and return the admin Machines link plus the device's non-secret enrollment status.
---

# Synopsis

Use this skill when a user wants an AI to install Tailscale on an authorized desktop and enroll it with a one-off auth key. Keep the key outside model context, determine whether the desktop connected or still needs administrator approval, and return the Tailscale Machines link with enough non-secret device identity for an administrator to find it.

# Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.

# Inputs

- Explicit authorization to install or modify Tailscale on the desktop.
- A one-off Tailscale auth key supplied by opaque secret reference through a trusted local secret channel, never as prompt text.
- Any non-secret enrollment settings the administrator requires, such as an approved hostname. Treat tags and other privileges encoded in the key as administrator-controlled policy.

# Outputs

- The installed Tailscale client version and service state.
- A non-secret enrollment result: already connected, connected, needs administrator approval, or failed/uncertain.
- The device hostname and Tailscale address when safely available.
- The Tailscale Machines link, `https://login.tailscale.com/admin/machines`, for administrator review or approval.

# Boundaries

- Never display, log, summarize, or place the auth key in prompts, model context, command arguments, shell history, files, source control, reports, or ordinary tool output.
- A trusted local helper may resolve the opaque secret reference and expose the key only to the Tailscale process through a protected environment or standard-input channel. Clear inherited secret state immediately afterward.
- Treat a one-off key as consumable. If the enrollment result is unknown, inspect local state before retrying and never consume another key without user direction.
- If Tailscale is already connected to a tailnet, do not reinstall or reauthenticate it. Return its non-secret state and the Machines link.
- Obtain installers only from official Tailscale distribution channels. Verify the publisher signature or package provenance when the platform supports it.
- Do not create or revoke auth keys, change tailnet policy, approve devices, or claim a per-device admin URL. Those are separate administrator operations.
- This skill describes a capability and does not grant authority to install software, join a tailnet, or alter administrator settings.

# Workflow

1. Detect the desktop operating system, confirm it is supported, and inspect whether Tailscale is installed, running, or already connected.
2. If the desktop is already connected, skip mutation and return the current non-secret identity, state, and Machines link.
3. If Tailscale is absent, obtain explicit installation authorization, use the current official installer for the platform, verify its provenance, install it, and confirm the client and service are available.
4. Confirm the supplied opaque secret reference identifies a one-off Tailscale auth key without rendering or validating the plaintext through model-visible output.
5. Have a trusted local helper inject the key directly into one `tailscale up` or equivalent enrollment process. Capture only redacted status, clear secret-bearing process state, and record whether the operation completed, failed, or is uncertain.
6. Query local Tailscale status without secrets. Distinguish a connected desktop from one awaiting device approval and preserve uncertainty when the observed state is inconclusive.
7. Return the device's non-secret identity and state with `https://login.tailscale.com/admin/machines`. Describe it as an approval link only when approval is actually required; otherwise describe it as the administrator's review link.

# Verification

- The Tailscale client and service are present and healthy, or the output clearly reports why installation failed.
- Local status identifies the desktop as connected, awaiting approval, or uncertain without exposing the auth key.
- No auth-key material appears in model context, logs, files, command history, process arguments, source control, status output, or reports.
- The returned administrator link is the Machines page and the device is identifiable there by the returned non-secret hostname or address.
