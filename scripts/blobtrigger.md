```
func new --template "BlobTrigger" --name boxblob
```

If everyhting looks good, lets publish to azure.
```
$functionsName = "ckriutzboxfunctions"
func azure functionapp publish $functionsName
```