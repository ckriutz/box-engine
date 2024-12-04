```
func new --template "ServiceBusQueueTrigger" --name boxsbqueue
```

If everyhting looks good, lets publish to azure.
```
$functionsName = "ckriutzboxfunctions"
func azure functionapp publish $functionsName
```