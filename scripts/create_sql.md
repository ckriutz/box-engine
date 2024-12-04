Make sure this is done in PowerShell

Set variables to use.
```
$resourceGroup = "rg-box-dev-westus2-01"
$location = "westus2"
$sqlServer = "boxenginesqlserver"
$adminUser = "boxuser"
$adminPassword = "++password1++"
$databaseName = "boxdb"
```

Start by creating a resource group:
```
az group create --name $resourceGroup --location $location
```

Now, create a sql server.
```
az sql server create --name $sqlServer --resource-group $resourceGroup --location $location --admin-user $adminUser --admin-password $adminPassword
```

Then, create a sql database!

```
az sql db create --resource-group $resourceGroup --server $sqlServer --name $databaseName --service-objective S0
```

Can't have a sql database without content! In the SQL Server panel, lets run a script to create some content.

First a table.

```
CREATE TABLE inventory (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Type NVARCHAR(100),
    Size NVARCHAR(50),
    Quantity INT
);
```

Then, some generic content.
```
INSERT INTO inventory (Name, Type, Size, Quantity) VALUES
('Widget A', 'Electronics', 'Small', 100),
('Gadget B', 'Electronics', 'Medium', 150),
('Tool C', 'Hardware', 'Large', 75),
('Appliance D', 'Household', 'Small', 50),
('Device E', 'Electronics', 'Large', 200),
('Item F', 'Office Supplies', 'Medium', 300),
('Gizmo G', 'Electronics', 'Small', 120),
('Accessory H', 'Fashion', 'Small', 80),
('Component I', 'Automotive', 'Large', 60),
('Part J', 'Machinery', 'Medium', 90);
```