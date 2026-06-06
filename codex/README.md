# Codex

This directory contains the canonical Codex instructions for this machine.

| Repo path | Local path |
|---|---|
| `codex/AGENTS.md` | `~/.codex/AGENTS.md` |

Use the root `README.md` reconciliation process as the default. The procedure below is a narrow extension for the common case where the repo file only adds instructions that are missing from the user-level file.

## Claude-to-Codex instruction comparison

When syncing Codex instructions on a machine that also has Claude instructions, compare the local files before deciding what to copy:

1. Read both local instruction files:

   ```sh
   diff -u --strip-trailing-cr ~/.codex/AGENTS.md ~/.claude/CLAUDE.md
   ```

2. Ignore Claude-specific and Codex-specific identity or tool wording, such as assistant names, vendor names, or instructions that only apply to one tool.

3. For each remaining content difference, follow the root `README.md` reconciliation process:

   - explain what the instruction does and its tradeoffs
   - show the current Codex and Claude values side by side
   - ask which action to take before editing

4. Apply only the approved changes to `~/.codex/AGENTS.md`, then verify the result against both the repo Codex file and the local Claude file as appropriate.

## Additive repo-to-local sync

1. Compare the repo file with the user-level file:

   ```sh
   diff -u --strip-trailing-cr codex/AGENTS.md ~/.codex/AGENTS.md
   ```

2. Confirm that every content difference is repo-only. Format-only differences, such as LF versus CRLF line endings or a missing final newline, do not count as content differences.

3. If the repo file is only additive, overwrite the user-level file:

   ```sh
   cp codex/AGENTS.md ~/.codex/AGENTS.md
   ```

4. Verify the files match after the copy:

   ```sh
   diff -u codex/AGENTS.md ~/.codex/AGENTS.md
   shasum -a 256 codex/AGENTS.md ~/.codex/AGENTS.md
   wc -l codex/AGENTS.md ~/.codex/AGENTS.md
   ```

## When not to overwrite

Do not use the additive sync procedure if the user-level file has local-only instructions or conflicting values. In that case, return to the root `README.md` process and resolve each difference individually.
