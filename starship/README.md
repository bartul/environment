# Starship Prompt

[Starship](https://starship.rs) is a fast, customizable cross-shell prompt. This config uses the Gruvbox Dark palette with a powerline-style layout showing Kubernetes context, directory, git branch/status/commit, language versions (C, Rust, Go, Node.js, Java, Kotlin, Haskell, Python, .NET, Helm), and environment context (Docker, Azure, conda, pixi).

## Install

Starship is included in the main `Brewfile`. If you've already run `brew bundle --file brew/Brewfile`, it's installed.

Otherwise install it directly:

```sh
brew install starship
```

## Configure Fish

Add the following line to `~/.config/fish/config.fish`:

```fish
starship init fish | source
```

This initializes the prompt on every new Fish session. The line must be at the end of the file so it runs after any path or environment setup.

## Install the Config

Copy the config file to the location Starship expects:

```sh
cp starship/starship.toml ~/.config/starship.toml
```

Starship picks up the file automatically — no shell restart needed, just open a new terminal.

## Update

```sh
brew upgrade starship
```
