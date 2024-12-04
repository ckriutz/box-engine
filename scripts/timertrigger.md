```
func new --name boxtimer --template "Timer trigger"
```

If there is an existing readme.md file, it will need to be deleted.

Then, update the trigger to reflect the updated code for shared data.

If everyhting looks good, lets publish to azure.
```
$functionsName = "ckriutzboxfunctions"
func azure functionapp publish $functionsName
```