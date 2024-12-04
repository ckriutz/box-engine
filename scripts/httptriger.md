```
func new --name boxhttp --template "HTTP trigger" --authlevel "anonymous"
```

Test the trigger locally.
```
func run
```

Now, add the Inventory class:
```
public class Inventory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
```

We can then adjust the Http function to return the list.
Here is a sample list:

```
private static List<Inventory> inventoryList = new List<Inventory>
{
    new Inventory { Id = 1, Name = "Square Box", Description = "A box that is square in dimentions", Quantity = 50 },
    new Inventory { Id = 2, Name = "Rectangle Box", Description = "Box, looks rectangle.", Quantity = 40 },
    new Inventory { Id = 3, Name = "Two-Dimentional Box", Description = "A box that is oddly 2d.", Quantity = 13 },
    new Inventory { Id = 4, Name = "Heavy Box", Description = "Despite the fact the box contains nothing, it is still heavy.", Quantity = 10 },
    new Inventory { Id = 5, Name = "Not Box", Description = "Even though it is called a box, it is not actually a box.", Quantity = 50 }
};
```

Change the function so it can respond to both get and post requests, then run again and use postman to test.

```
func start
```

If everyhting looks good, lets publish to azure.
```
$functionsName = "ckriutzboxfunctions"
func azure functionapp publish $functionsName
```