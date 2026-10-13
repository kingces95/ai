# Trust, publication, and branch policy

## Public policy

GitHub is the public source of truth. A branch name, including `main`, identifies repository state but does not by itself prove that Chris approved it for publication.

An authenticated publication is a commit referenced by an immutable annotated Git tag whose signature:

- is valid for the exact tagged Git object;
- was made with the dedicated publication key registered as a signing key on Chris's GitHub account; and
- is reported as verified by GitHub or independently verifies against the public key retrieved from GitHub through an authenticated connection.

Consumers decide what an authenticated publication authorizes under their own rules. Authentication establishes that the holder of the publication private key approved the tagged state; it does not attest that the content is suitable for a particular use.

To verify a publication:

1. Fetch the repository and its tags from GitHub.
2. Select the intended annotated publication tag.
3. Confirm that GitHub reports the tag signature as verified, or retrieve the signing key from GitHub and run `git verify-tag <tag>` locally.
4. Confirm the tag targets the expected commit and apply local freshness, version, and rollback policy.

The publication private key is separate from internal collaboration credentials and is hardware protected. No public or private key stored in this repository is a trust anchor. Publication keys may rotate, so consumers must also apply the continuity and rotation guidance in [KEYS.md](KEYS.md).

## Internal workflow

CLOUD hosts an internal collaboration origin and distribution cache. Internal machines normally clone and exchange work through CLOUD for speed and availability. CLOUD is not the public trust anchor and may contain branches or commits that have not been published.

The internal human principals are `chris`, `sam`, and `adrienne`. Working branches conventionally use the principal name. Each participating machine holds a private key and a CA-issued SSH certificate authorizing a principal; a principal may deliberately delegate its credential to local bots or agents. Branch names organize work, while signatures authenticate it.

Each client receives the internal CA trust anchor outside this repository and applies its own policy. Our convention is:

- clients may trust work on their own principal branch according to local policy;
- other principal branches are signed proposals;
- internal `main` is accepted only when its tip has a valid certificate-backed signature for principal `chris`; and
- publication copies that exact accepted commit to GitHub and adds a dedicated signed publication tag.

The normal direction is internal work to CLOUD, then an explicitly requested publication to GitHub. GitHub's published history is canonical for public consumers. New internal work continues on CLOUD until the next publication. Clients may clone from CLOUD, but must not infer public approval merely because an object or branch exists there.

Server-side protections may supplement this model, but clients remain responsible for verifying signatures before treating repository content as trusted instructions or executing it.
