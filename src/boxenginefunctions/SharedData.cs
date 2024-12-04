public class SharedData
{
    public List<Inventory> InventoryList { get; set; } =  new List<Inventory>
    {
        new Inventory { Id = 1, Name = "Square Box", Description = "A box that is square in dimentions", Quantity = 50 },
        new Inventory { Id = 2, Name = "Rectangle Box", Description = "Box, looks rectangle.", Quantity = 40 },
        new Inventory { Id = 3, Name = "Two-Dimentional Box", Description = "A box that is oddly 2d.", Quantity = 30 },
        new Inventory { Id = 4, Name = "Heavy Box", Description = "Despite the fact the box contains nothing, it is still heavy.", Quantity = 20 },
        new Inventory { Id = 5, Name = "Not Box", Description = "Even though it is called a box, it is not actually a box.", Quantity = 10 }
    };
}