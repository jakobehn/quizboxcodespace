az aks enable-addons `
    --resource-group tdswe-test `
    --name tdswe-test `
    --addons virtual-node `
    --subnet-name vnodes