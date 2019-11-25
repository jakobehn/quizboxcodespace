[CmdletBinding()]
param (
    [string]$resourceGroup,
    [string]$vnet,
    [string]$appId
)

$vnetId = (az network vnet show --resource-group $resourceGroup --name $vnet --query id -o tsv)


az role assignment create --assignee $appId --scope $vnetId --role Contributor

az aks enable-addons `
    --resource-group tdswe-test `
    --name tdswe-test `
    --addons virtual-node `
    --subnet-name vnodes