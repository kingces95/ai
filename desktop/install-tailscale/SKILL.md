---
name: install-tailscale
description: Install and enroll Tailscale with a remembered one-time key, guide administrator approval, verify connection, and forget the key without exposing it.
---

# Synopsis

Use this skill when a user wants the AI to install Tailscale on an authorized desktop and join it to a network with a remembered one-time key. Guide any administrator approval and forget the key when it is no longer needed.

# Skills

- [describe-skill](../../meta/describe-skill) — skill description and composition contract.
- [save-secret](../save-secret) — remember the one-time key for later use and forget it when finished.

# Inputs

- Explicit authorization to install or modify Tailscale on the desktop.
- A one-time Tailscale auth key remembered with `save-secret`, never supplied as prompt text.
- Any non-secret enrollment settings the administrator requires, such as an approved hostname. Treat tags and other privileges encoded in the key as administrator-controlled policy.

# Outputs

- The installed Tailscale client version and service state.
- A non-secret enrollment result: already connected, connected, needs administrator approval, or failed/uncertain.
- The device hostname and Tailscale address when safely available.
- The Tailscale Machines link, `https://login.tailscale.com/admin/machines`, for administrator review or approval.
- A simple way to learn that the administrator finished, followed by forgetting the one-time key.

# Boundaries

- Never display, log, summarize, or place the auth key in prompts, model context, command arguments, shell history, files, source control, reports, or ordinary tool output.
- Treat a one-off key as consumable. If the enrollment result is unknown, inspect local state before retrying and never consume another key without user direction.
- Opening the Machines link is not by itself proof that the administrator completed approval. Use a suitable confirmation or observable status before forgetting the key.
- If Tailscale is already connected to a tailnet, do not reinstall or reauthenticate it. Return its non-secret state and the Machines link.
- Obtain installers only from official Tailscale distribution channels. Verify the publisher signature or package provenance when the platform supports it.
- Do not create or revoke auth keys, change tailnet policy, approve devices, or claim a per-device admin URL. Those are separate administrator operations.
- This skill describes a capability and does not grant authority to install software, join a tailnet, or alter administrator settings.

# Workflow

Install Tailscale if needed, use the remembered key to enroll the desktop, and report whether it connected or needs administrator approval. When approval is needed, give the administrator the Machines link and provide a simple completion experience. Once the desktop has joined successfully, forget the one-time key.

Choose installation, confirmation, and cleanup mechanics appropriate to the environment. Preserve uncertainty rather than retrying a possibly consumed key or claiming approval succeeded without evidence.

# Verification

- The Tailscale client and service are present and healthy, or the output clearly reports why installation failed.
- Local status identifies the desktop as connected, awaiting approval, or uncertain without exposing the auth key.
- No auth-key material appears in model context, logs, files, command history, process arguments, source control, status output, or reports.
- The returned administrator link is the Machines page and the device is identifiable there by the returned non-secret hostname or address.
- The UX can report administrator completion, and the AI forgets the key after successful enrollment.
