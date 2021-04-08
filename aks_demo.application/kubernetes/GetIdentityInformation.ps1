
# Collect principals and resource group for Managed Identity Role Assignments
#!!!!!!!!!!!! Change these to your installations values!
$subscription = "722daa54-db9c-4486-81e8-fe8e9c3a8773"
$aksResourceGroup = "hwdemo-rg-westus-aks"
$aksName = "hwdemo-aks-westus"

$aks = az aks show --resource-group $aksResourceGroup --name $aksName --subscription $subscription | ConvertFrom-Json
$userAssignedIdentity = az resource list -g $aks.nodeResourceGroup --subscription $subscription --query "[?contains(type, 'Microsoft.ManagedIdentity/userAssignedIdentities')] | [?ends_with(name,'agentpool')]" | ConvertFrom-Json      
$identity = az identity show -n $userAssignedIdentity.name -g $userAssignedIdentity.resourceGroup --subscription $subscription | ConvertFrom-Json
$identityName = $identity.name.ToLower()
$identityId = $identity.id
$identityClientId = $identity.clientId

echo ClientID: $identityClientId
echo identityId: $identityId 
echo identityName: $identityName 