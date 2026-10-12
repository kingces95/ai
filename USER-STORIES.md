# User stories

Each entry is the primary user story for one skill and links to its implementation contract.

- [`describe-skill`](meta/describe-skill): As a skill maintainer, I want every skill expressed through a compact, consistent contract and indexed by its primary user story, so that I can compose the library and run schema-conformance passes safely.
- [`create-secret`](desktop/create-secret): As a user, I want my AI to perform an authorized provisioning flow and create the passwords it needs, so that at the end it can give me those credentials in a format I can import into my password manager.
- [`save-secret`](desktop/save-secret): As a user, I want my AI to securely remember a secret I copy, so that it can use the secret later without asking me to expose it in chat.
- [`install-tailscale`](desktop/install-tailscale): As a desktop user, I want my AI to install Tailscale with a remembered one-time key, guide administrator approval, and forget the key after verifying connection, so that the desktop joins the network without the secret appearing in chat or logs.

