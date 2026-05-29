# Prioritize Homebrew binaries over system binaries
fish_add_path -p /opt/homebrew/bin
fish_add_path $HOME/.dotnet/tools

if status is-interactive
    set -g fish_key_bindings fish_vi_key_bindings
    bind -M insert ctrl-r history-pager
    starship init fish | source
end
