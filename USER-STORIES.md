# User stories

Each entry is the primary user story for one skill and links to its implementation contract.

- [`describe-skill`](meta/describe-skill): As a skill maintainer, I want every skill expressed through a compact, consistent contract and indexed by its primary user story, so that I can compose the library and run schema-conformance passes safely.
- [`create-secret`](desktop/create-secret): As a user, I want my AI to perform an authorized provisioning flow and create the passwords it needs, so that at the end it can give me those credentials in a format I can import into my password manager.
- [`save-secret`](desktop/save-secret): As a user, I want my AI to remember a secret it has obtained for later recall on this machine, so that explicit requests and composed workflows can use it without exposing it in chat.
- [`accept-secret`](desktop/accept-secret): As a user, I want my AI to present a simple experience for accepting a copied secret, so that it can remember and use the secret later without exposing it in chat.
- [`install-tailscale`](desktop/install-tailscale): As a desktop user, I want my AI to install Tailscale with a remembered one-time key, guide administrator approval, and forget the key after verifying connection, so that the desktop joins the network without the secret appearing in chat or logs.

