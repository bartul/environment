# Fish Shell Config

## Machine-specific paths

The `config.fish` in this repo targets **Apple Silicon** Macs. The Homebrew binary path differs by architecture:

| Architecture | Path |
|---|---|
| Apple Silicon (arm64) | `/opt/homebrew/bin` |
| Intel (x86_64) | `/usr/local/bin` |

When syncing `config.fish` to a non-Apple Silicon machine, change the `fish_add_path -p /opt/homebrew/bin` line to use the appropriate path for that machine. Do not commit machine-specific paths back to the repo — this repo's version stays as the Apple Silicon reference.
