# User stories

Each entry is the primary user story for one skill and links to its implementation contract.

- [`describe-skill`](meta/describe-skill): As a skill maintainer, I want every skill expressed through a compact, consistent contract and indexed by its primary user story, so that I can compose the library and run schema-conformance passes safely.
- [`create-secret`](desktop/create-secret): As a user, I want my AI to perform an authorized provisioning flow and create the passwords it needs, so that at the end it can give me those credentials in a format I can import into my password manager.
- [`save-secret`](desktop/save-secret): As a user, I want to copy a secret and explicitly hand it to a small local helper that stores it with context inferred by my AI, so that later provisioning steps can reference the secret without exposing it to the AI or its logs.
- [`install-tailscale`](desktop/install-tailscale): As a desktop user, I want my AI to install Tailscale with a privately stored one-off key, guide administrator approval, and retire the key after verifying connection, so that the desktop joins the network without the secret appearing in chat or logs.

