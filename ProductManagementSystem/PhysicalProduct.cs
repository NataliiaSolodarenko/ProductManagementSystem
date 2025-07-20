// Represents a physical (tangible) product
public class PhysicalProduct : Product, IDiscountable
{
    // Product weight in kilograms
    public double Weight { get; set; }
    // Product dimensions: width, height, depth (in meters)
    public List<double> Dimensions { get; set; } = new List<double> { -1, -1, -1 };

    // Constructor with input validation and default fallbacks
    public PhysicalProduct(string? name, double price, int stock, ProductCategory? category, double discount, double weight, List<double>? dimensions)
    {
        // Assign a default name if null
        Name = name ?? "NoNameProduct";

        // Assign valid price (> 0)
        if (price > 0)
            Price = price;

        // Assign valid stock (>= 0)
        if (stock >= 0)
            Stock = stock;

        // Assign category or fallback to Other
        Category = category ?? ProductCategory.Other;

        // Assign valid discount in range [0, 100]
        if (discount >= 0 && discount <= 100)
            Discount = discount;

        // Assign weight if positive
        if (weight > 0)
            Weight = weight;

        // Assign dimensions only if 3 valid positive values are provided
        if (dimensions?.Count == 3)
            if (dimensions[0] > 0 && dimensions[1] > 0 && dimensions[2] > 0)
                Dimensions = dimensions;

    }

    // Applies a percentage discount to the product price
    public void ApplyDiscount()
    {
        Price = Math.Round(Price - Price * Discount / 100, 2);
    }
}