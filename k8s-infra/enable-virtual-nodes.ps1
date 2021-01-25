az aks enable-addons `
    --resource-group ndc-test `
    --name ndc-test `
    --addons virtual-node `
    --subnet-name vnodes