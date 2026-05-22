# Claude

This directory contains the canonical Claude instructions for this machine.

| Repo path | Local path |
|---|---|
| `claude/CLAUDE.md` | `~/.claude/CLAUDE.md` |

Use the root `README.md` reconciliation process as the default. The procedure below is a narrow extension for the common case where the repo file only adds instructions that are missing from the user-level file.

## Additive repo-to-local sync

1. Compare the repo file with the user-level file:

   ```sh
   diff -u --strip-trailing-cr claude/CLAUDE.md ~/.claude/CLAUDE.md
   ```

2. Confirm that every content difference is repo-only. Format-only differences, such as LF versus CRLF line endings or a missing final newline, do not count as content differences.

3. If the repo file is only additive, overwrite the user-level file:

   ```sh
   cp claude/CLAUDE.md ~/.claude/CLAUDE.md
   ```

4. Verify the files match after the copy:

   ```sh
   diff -u claude/CLAUDE.md ~/.claude/CLAUDE.md
   shasum -a 256 claude/CLAUDE.md ~/.claude/CLAUDE.md
   wc -l claude/CLAUDE.md ~/.claude/CLAUDE.md
   ```

## When not to overwrite

Do not use the additive sync procedure if the user-level file has local-only instructions or conflicting values. In that case, return to the root `README.md` process and resolve each difference individually.
