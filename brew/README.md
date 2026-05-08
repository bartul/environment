# Homebrew Setup

This folder uses a `Brewfile` to install command-line tools, fonts, and macOS apps through Homebrew Bundle.

## Requirements

Homebrew must be installed before this Brewfile can be used. The `brew` command also needs to be available in the current shell.

After installing Homebrew, follow the shell setup instructions printed by the installer so `brew` is available in new terminal sessions.

## Install Homebrew

Install Homebrew with the official shell installer:

```sh
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

On macOS, Homebrew also provides a `.pkg` installer through the [latest Homebrew GitHub release](https://github.com/Homebrew/brew/releases/latest).

For current install options and platform requirements, see the official Homebrew installation docs:

https://docs.brew.sh/Installation

## Install From The Brewfile

From the repository root, install everything listed in the Brewfile:

```sh
brew bundle --file brew/Brewfile
```

To check what would be installed without making changes:

```sh
brew bundle check --file brew/Brewfile
```

To add a new package or app, edit `brew/Brewfile`:

```ruby
brew "jq" # Command-line JSON processor
cask "visual-studio-code" # Code editor
tap "microsoft/git" # External Homebrew formula repository
```

Use `brew "name"` for command-line formulae, `cask "name"` for GUI apps and fonts, and `tap "owner/repo"` for external Homebrew repositories.
