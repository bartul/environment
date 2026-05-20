# Homebrew Setup

This folder uses two Brewfiles to install everything through Homebrew Bundle:

- `Brewfile` — command-line tools, casks, and fonts
- `Brewfile.mas` — Mac App Store apps, installed via the `mas` directive

## Requirements

Homebrew must be installed before either Brewfile can be used. The `brew` command also needs to be available in the current shell.

After installing Homebrew, follow the shell setup instructions printed by the installer so `brew` is available in new terminal sessions.

`Brewfile.mas` additionally requires:

- The `mas` CLI, which is installed by the main `Brewfile`. Install `Brewfile` first.
- An active Mac App Store sign-in. Open the App Store app and sign in before running `brew bundle` against `Brewfile.mas`.

## Install Homebrew

Install Homebrew with the official shell installer:

```sh
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

On macOS, Homebrew also provides a `.pkg` installer through the [latest Homebrew GitHub release](https://github.com/Homebrew/brew/releases/latest).

For current install options and platform requirements, see the official Homebrew installation docs:

https://docs.brew.sh/Installation

## Install From The Brewfiles

From the repository root, install command-line tools, casks, and fonts:

```sh
brew bundle --file brew/Brewfile
```

Then install Mac App Store apps (requires being signed into the App Store):

```sh
brew bundle --file brew/Brewfile.mas
```

To check what would be installed without making changes:

```sh
brew bundle check --file brew/Brewfile
brew bundle check --file brew/Brewfile.mas
```

To add a new package or app, edit `brew/Brewfile`:

```ruby
brew "jq" # Command-line JSON processor
cask "visual-studio-code" # Code editor
tap "owner/repo" # External Homebrew formula repository
```

Use `brew "name"` for command-line formulae, `cask "name"` for GUI apps and fonts, and `tap "owner/repo"` for external Homebrew repositories.

To add a Mac App Store app, edit `brew/Brewfile.mas`:

```ruby
mas "App Name", id: 1234567890
```

Find an app's numeric ID with `mas search "app name"` or `mas list` for already-installed apps.
