---
name: install-tailscale
description: Install and enroll Tailscale with a one-time key, guide administrator approval, verify connection, and forget the key without exposing it.
---

# Prompt

Install Tailscale on this machine and join it to the intended network using a one-time secret. If administrator approval is required, provide the administrator link and a simple way to learn when approval is complete. Forget the one-time secret after the machine has joined successfully.

# Synopsis

Use this skill when a user wants the AI to install Tailscale on an authorized machine and join it to a network. Use `crud-secret` to accept, recall, and delete the one-time key without exposing it.

# Skills

- [describe-skill](../describe-skill) — skill description and composition contract.
- [crud-secret](../crud-secret) — accept, recall, and forget the one-time key without exposing it.

# Inputs

- Authorization to install or modify Tailscale on the machine.
- A one-time Tailscale auth key managed with `crud-secret`.
- Any enrollment context required by the administrator.

# Outputs

- Tailscale installed and the machine connected, awaiting approval, or clearly reported as unresolved.
- The Tailscale Machines link, `https://login.tailscale.com/admin/machines`, when administrator review or approval is useful.
- A simple completion experience and confirmation that the one-time key was forgotten after successful enrollment.

# Boundaries

- Never expose the auth key in conversation, logs, reports, command arguments, or other model-visible output.
- Treat a one-time key as consumable and preserve uncertainty instead of retrying it blindly.
- Opening the administrator link is not by itself proof that approval completed.
- Do not disturb an existing working Tailscale connection or change tailnet policy without separate authority.

# Workflow

Install Tailscale if needed, use the remembered key to enroll the machine, and report whether it connected or needs administrator approval. When approval is needed, give the administrator the Machines link and provide a suitable way to learn that the flow finished. Once enrollment succeeds, delete the key through `crud-secret`.

Choose installation, confirmation, and cleanup mechanics appropriate to the environment.

# Verification

- Tailscale reports the machine connected, awaiting approval, or unresolved without exposing the key.
- The administrator can identify the machine from the information provided.
- The one-time key is forgotten after successful enrollment.
