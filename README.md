# AzureRemoteDesktopStatus

## Setup

[Doc here](https://docs.microsoft.com/fr-fr/dotnet/azure/dotnet-sdk-azure-authenticate?view=azure-dotnet)

    cd .\AzureRemoteDesktopStatus\src\
    az login
    az account show
    az ad sp create-for-rbac --sdk-auth | Out-File "azureauth.json"
    dotnet run

## Todo

- Add check for VM up before & after start
- Check if IP is ok
- Launch RDP if TCP to 3389 is ok
