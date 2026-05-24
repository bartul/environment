# Environment

Canonical reference configurations for this machine. Each directory maps to a specific tool's config file(s).

## Config map

| Repo path | Local path |
|---|---|
| `git/.gitconfig` | `~/.gitconfig` |
| `ghostty/config` | `~/Library/Application Support/com.mitchellh.ghostty/config` |
| `vscode/settings.json` | `~/Library/Application Support/Code/User/settings.json` |
| `zed/settings.json` | `~/.config/zed/settings.json` |
| `fish/config.fish` | `~/.config/fish/config.fish` |
| `starship/starship.toml` | `~/.config/starship.toml` |
| `claude/CLAUDE.md` | `~/.claude/CLAUDE.md` |
| `brew/Brewfile` | used with `brew bundle` |

Each tool directory may contain its own `README.md` with additional instructions and tool-specific notes that supplement this document — check there first before reconciling that tool's config.

## Reconciliation process

When syncing a config between local and this repo, follow this process one difference at a time:

### 1. Read both files

Read the repo file and the corresponding local file from the path in the config map above.

### 2. Diff them

Identify every difference. Group them into categories:

- **Repo-only** — setting exists in repo but not locally
- **Local-only** — setting exists locally but not in repo
- **Value differs** — both have the setting but with different values
- **Format only** — same content, different whitespace/comments (resolve silently, no need to ask)

### 3. Go through each difference one at a time

For each difference:

1. **Explain the setting** — look up and describe what it does, what values are valid, and what the tradeoffs between those values are. Never present a choice without this context.
2. **Show the diff** — display the current value in each location side by side.
3. **Offer resolution options** — ask which direction to resolve:

- **A** — Take the repo version (update local to match)
- **B** — Take the local version (update repo to match)
- **C** — Merge both (keep both in sync with combined result)
- **D** — Drop it from both

Use judgment on which options to offer — machine-specific settings (credential helpers, hardware paths) usually shouldn't go in the repo; general preferences should be in both.

### 4. Apply the decision immediately

Make the edit before moving to the next difference. Keep changes atomic.

### 5. After all differences are resolved

- If the repo file changed: commit and push
- If only the local file changed: nothing to commit
- If both changed: commit and push the repo changes

### 6. Format check

After reconciliation, check the local file for formatting consistency (indentation, blank lines between sections). Clean it up if needed — no need to ask for approval on whitespace-only fixes.
