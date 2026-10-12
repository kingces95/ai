# ai-lastpass — Onboarding Runbook (trial log)

Trial: 2026-10-11. Onboarding a GitHub machine-user (email `kingces95+muse@gmail.com`,
GitHub username `kingces95-muse`) using Chris's own LastPass account as the
credential store. (Plus-addressing chosen over a separate `kingces95-muse@gmail.com`
inbox — verification mail lands in kingces95@gmail.com.)

## Intended flow

1. Muse opens the LastPass web vault (`vault.lastpass.com`) in the browser.
2. Human takes over and types their own master password (+ any LastPass 2FA).
   The Muse NEVER sees, asks for, or enters the master password.
3. Muse creates a Password item: Name `GitHub - kingces95-muse`,
   Username = new GitHub username, URL `https://github.com`,
   password from LastPass's built-in generator (DOM-only — the Muse clicks
   Generate and Save without ever reading the password field).
4. Item verified present in the vault list.

## Speed bumps

### 1. LastPass blocked the login as an unrecognized device (2026-10-11)
- What happened: after Chris typed his master password in the automation
  browser, LastPass blocked the attempt ("Login attempt blocked" email to
  kingces95@gmail.com, 14:44 HST) instead of sending a plain device-verification
  link. Cause: the automation browser exits via the Hatch egress proxy
  (Cloudflare IP 104.28.216.43), which LastPass had never seen.
- How we confirmed it was us: timestamp matched the login to the minute,
  location Honolulu, account kingces95@gmail.com.
- Resolution: the email has a **"Verify new device or location"** button.
  Its URL contains a one-time bearer token — the runtime redacts it as a
  credential, so the Muse CANNOT click it. The human must click it themselves
  in their own Gmail app.
- After verifying, the vault login must be RE-SUBMITTED in the browser
  (the original attempt was blocked, not queued).
- Skill rule to encode: treat the verify-device link as a credential. Never
  ask the Muse to extract or open it. Human clicks it, then retries login.
- REFINED 2026-10-11 (trial with Chris): the human *decides*, the Muse may
  *execute*. Chris explicitly delegated the click; the browser opened his
  Gmail (Google SSO session carried over from the earlier console sign-in —
  no separate Gmail login needed) and clicked "Verify new device or location"
  in-page. The token never entered the Muse's context. Verification
  succeeded ("Thanks for verifying!"), then the vault login was re-submitted
  by Chris himself.

### 4. Generated password leaked through one tool observation (2026-10-11)
- HONEST FINDING: the "DOM-only" guarantee did not fully hold. LastPass's
  password-suggestion dialog rendered its label text including the generated
  password in plain text, and that rendering passed through one browser-tool
  observation. The task did not copy, type, display, or act on it, and the
  value is not in its report — but it exists in the transcript.
- Implication for the skill spec: the guarantee must be stated as "the Muse
  never *handles or uses* the password," not "the password never appears in
  any rendering." UI quirks can flash secrets through observations.
- Mitigation offered to the human: one-click regenerate in the vault if the
  exposure bothers them (password unused anywhere yet at this point).
- Incidents also logged: Escape on the suggestion dialog triggered "Discard
  unsaved changes?" (clicked "Keep editing," no loss); multi-tab unavailable
  so Gmail was visited in the same tab and back — no issue.

### 5. GitHub signup hard-blocked by DataDome on the automation IP (2026-10-11)
- github.com/signup served "Access is temporarily restricted" (DataDome):
  "unusual activity from your device or network ... automated (bot) activity
  on your network (IP 104.28.216.43)". No CAPTCHA to solve — hard wall, only
  a "Submit feedback" link. Same Cloudflare egress IP LastPass flagged.
- This is an artifact of the Hatch VM's datacenter egress IP, not of the
  onboarding design: on a friend's residential IP / own device, signup should
  proceed normally with the Muse driving + human checkpoints.
- Skill rule: the GitHub account-creation step runs on the HUMAN's own
  device and network. The Muse preps everything (vault item with generated
  password, email, username) and resumes after (2FA is also human-side;
  PAT + git config are Muse-side once the account exists).
- Trial resolution: Chris signs up himself on his own device — email
  kingces95+muse@gmail.com, username kingces95-muse, password from the
  "GitHub - kingces95-muse" vault item (his LastPass account, accessible
  anywhere).

### 3. Vault "Loading..." splash + reload kills the session (2026-10-11)
- After login, the vault hung on its "Loading..." splash. The browser task
  reloaded the page to unstick it — the reload landed on
  `lastpass.com/logout?skip_prompt=1` and ended the session.
- Device verification survived (one-time), so re-login needed only the
  master password, no new device block.
- Skill rule: NEVER reload a stuck vault page. Wait it out, or if truly
  hung, hand off to the human. A reload = forced re-login.

### 2. Takeover handoff for master password worked as designed
- Browser task paused with `ask_for_information`; Chris took over and typed
  the password himself. No secret touched the Muse. Pattern confirmed.

## Design: the Muse as the user's finger (opt-in) — the vaca-friend experience

Adopted 2026-10-11. For each security step the skill offers the choice:

- The friend grants the Muse Gmail visibility (connected Gmail account, or a
  Google session carried over in the automation browser).
- At each attestation/verification step, the Muse ASKS: "I found the
  verification email — want me to click the button for you, or do you want
  to do it?" The human decides per step (or sets a standing preference).
- If delegated, the Muse clicks in-page; bearer tokens never enter its
  context, logs, or reports.

Categories (encode in the skill spec):

| Category | Examples | Rule |
|---|---|---|
| Secrets | LastPass master password | Human-only, always. The Muse never sees, handles, or transports. |
| Attestations | "Verify new device", "Yes, it was me" | Human DECIDES; Muse may execute the click as finger only on explicit per-step delegation. Never initiates. |
| Single-use codes | SMS 2FA codes read aloud by the user | May be relayed/entered by the Muse as finger when explicitly asked for that step. |

Rationale: the security property is preserved because the human remains the
decision-maker. The failure mode we avoid is the Muse *routinely*
auto-attesting, which would fire during a real attack too. Opt-in per-step
delegation keeps the human in the loop while removing the tedious parts.
