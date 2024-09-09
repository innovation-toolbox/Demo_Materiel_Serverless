# Demo Steps

1. Open the Devcontainer & VSCode Workspace 
1. Log in Az Cli : az login fe85910f-e6e0-43da-a1ec-9e4e94a9f6c4 --use-device-code
1. Execute the following commands : 
    ```
    cd src/function/python2 
    python -m venv .venv
    source .venv/bin/activate
    func init --python
    func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"
    ```
