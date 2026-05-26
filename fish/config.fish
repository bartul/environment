set -x PATH $PATH /usr/local/bin/

fish_add_path $HOME/.dotnet/tools

if status is-interactive
    set -g fish_key_bindings fish_vi_key_bindings
    starship init fish | source
end
