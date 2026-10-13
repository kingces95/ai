# Publication keys

## Trust anchor

The public repository's approval signal is a valid signature on an annotated publication tag. The signing key is registered as an SSH signing key on the publisher's GitHub account. Retrieve the key through an authenticated GitHub connection or use GitHub's verified-signature result; do not treat a key copied from this repository as a trust anchor.

The private half of the current publication key is non-exportable and held by the Windows hardware-backed cryptographic provider on the publishing Gram. It is separate from internal commit-signing identities and is restricted locally to signing annotated Git tags that target commits.

## Rotation

Publication keys may be rotated because of routine lifecycle management, hardware replacement, suspected compromise, or changes in cryptographic policy. Consumers should design acceptance policy for rotation rather than pinning one key forever.

A practical policy keeps an explicit set of accepted current and retired public keys together with the tag names, sequence, or time intervals for which each key is valid. Authenticate a replacement key through the publisher's GitHub account or another independently trusted continuity event before accepting tags made by it. Removing a retired key from GitHub must not retroactively invalidate immutable tags that were accepted while that key was authorized; retain the retired public key wherever historical offline verification is required.

A valid signature from a rotated-out or revoked key is proof that the key made the signature, not that the publication remains acceptable. Consumers must also apply their own compromise, revocation, freshness, and rollback rules.

## Local operation

Key custody and signing instructions are machine-local and intentionally absent from the repository. On the publishing Gram, the runbook is stored at `C:\Users\chris\.codex\ai-publishing\README.md`. Signing is an explicit human-directed operation; it is never implied by merging or pushing `main`.
