# VS Code

This directory supplements the root reconciliation procedure. Follow the root
`README.md` first, then use the VS Code-specific notes below for extensions.

## Files

- `settings.json` is the canonical VS Code user settings file.
- `extensions.txt` is the canonical VS Code extension manifest.
- `install-extensions.fsx` installs the extensions from `extensions.txt`.

## Extension Manifest

`extensions.txt` contains one extension ID per line. Blank lines split logical
sections. Each extension line must include an inline `#` comment describing why
the extension is included.

Example:

```text
redhat.vscode-yaml # YAML language support, validation, formatting, and Kubernetes schema help.
```

The installer ignores blank lines and anything after `#`, so descriptions are
safe to keep in the manifest.

## Compare Installed Extensions

Compare repo extensions to the locally installed VS Code extensions with
case-insensitive IDs:

```sh
comm -23 \
  <(awk -F'#' '{gsub(/^[[:space:]]+|[[:space:]]+$/, "", $1); if ($1 != "") print tolower($1)}' vscode/extensions.txt | sort -u) \
  <(code --list-extensions 2>/dev/null | tr '[:upper:]' '[:lower:]' | sort -u)
```

The command above prints repo-only extensions.

```sh
comm -13 \
  <(awk -F'#' '{gsub(/^[[:space:]]+|[[:space:]]+$/, "", $1); if ($1 != "") print tolower($1)}' vscode/extensions.txt | sort -u) \
  <(code --list-extensions 2>/dev/null | tr '[:upper:]' '[:lower:]' | sort -u)
```

The command above prints local-only extensions.

## Resolve Each Difference

Resolve one extension at a time using the root README options:

- `A` means take the repo version. For repo-only extensions, install locally.
  For local-only extensions, uninstall locally.
- `B` means take the local version. For local-only extensions, add the extension
  ID to `extensions.txt` with an inline description.
- `C` means merge or replace both sides with the best canonical extension ID.
  Use this when an extension was renamed or replaced.
- `D` means remove it from both places.

Before presenting an extension decision, include:

- what the extension does
- current Marketplace last update date and version
- whether it still appears supported
- popularity signal, usually install count and rating count
- source/support links when available
- the repo/local state and the applicable options

Prefer current publisher IDs over stale or renamed IDs. If there are competing
extensions for the same purpose, check whether a more popular or better
maintained alternative should be canonical before adding it to the manifest.

## Install Or Validate

Use the F# installer through `dotnet fsi`:

```sh
dotnet fsi --exec -- vscode/install-extensions.fsx
```

Run a dry-run after editing the manifest:

```sh
dotnet fsi --exec -- vscode/install-extensions.fsx --dry-run
```

The dry-run should print one `code --install-extension <id>` command for each
non-empty extension line.

The script also supports:

```sh
dotnet fsi --exec -- vscode/install-extensions.fsx --help
dotnet fsi --exec -- vscode/install-extensions.fsx --extensions-file <path>
dotnet fsi --exec -- vscode/install-extensions.fsx --code <command>
```

## Final Checks

After all decisions are applied:

1. Confirm repo-only and local-only comparison commands print no extensions.
2. Confirm every non-empty extension line has an inline description.
3. Run `dotnet fsi --exec -- vscode/install-extensions.fsx --dry-run`.
4. Run `git diff --check`.
5. Commit and push if `extensions.txt`, `settings.json`, or this README changed.
