// Abstract base class for all products (e.g., physical or digital)
public abstract class Product
{
    // Product name
    public string Name { get; set; } = "";
    // Product price in UAH
    public double Price { get; set; }
    // Available stock count
    public int Stock { get; set; }
    // Discount percentage (0–100)
    public double Discount { get; set; }
    // Product category (enum)
    public ProductCategory Category { get; set; }

    // Event triggered when stock falls below a threshold
    public event Action<string> OnLowStock = (message) => Console.WriteLine(message);

    // Method to sell a specific number of products
    public void SellProduct(int count)
    {
        // If requested count exceeds stock, sell only what's left
        if (count > Stock)
            count = Stock;

        // Decrease stock and notify purchase
        Stock -= count;
        Console.WriteLine($"\nProduct \"{Name}\" was purchased in the amount of {count}.");

        // Trigger low stock warning if necessary
        if (Stock < 5)
            OnLowStock?.Invoke($"\nProduct \"{Name}\" is almost sold out!");
    }
}