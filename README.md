# AzureRemoteDesktopStatus

## Setup

[Doc here](https://docs.microsoft.com/fr-fr/dotnet/azure/dotnet-sdk-azure-authenticate?view=azure-dotnet)

    az login
    az account show
    az ad sp create-for-rbac --sdk-auth | Out-File "azureauth.json"
    dotnet run
