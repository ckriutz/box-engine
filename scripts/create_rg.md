## Setting up the environment in Azure.

First, some environment variables

```
$resourceGroup = "rg-box-dev-westus2-01"
$location = "westus2"
$storageName = "ckriutzfuncstorage002"
$functionsName = "ckriutzboxfunctions"
$serviceBusNameSpace = "boxservicebusns"
$serviceBusQueueName = "boxservicebusqueue"
$blobstorageName = "ckriutzblobstorage002"
```

Now, lets use this to create a resource group.

```
az group create -l $location -n $resourceGroup

```

Then, once that's created, lets go ahead and create a storage account.


```
az storage account create --name $storageName --location $location --resource-group $resourceGroup --sku Standard_LRS --allow-blob-public-access false
```

Finally, the function app in Azure.
```
az functionapp create --resource-group $resourceGroup --consumption-plan-location $location --runtime dotnet-isolated --functions-version 4 --name $functionsName --storage-account $storageName
```

For message bus, we need to create this.
```
az servicebus namespace create --resource-group $resourceGroup --name $serviceBusNameSpace --location $location --sku Standard

az servicebus queue create --name $serviceBusQueueName --namespace-name $serviceBusNameSpace --resource-group $resourceGroup
```

For blob storage trigger, we need to create a seperate storage account.

```
az storage account create --name $blobstorageName --location $location --resource-group $resourceGroup --sku Standard_LRS --allow-blob-public-access true
```