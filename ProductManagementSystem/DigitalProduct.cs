// Represents a physical (tangible) product
public class DigitalProduct : Product, IDiscountable
{
    // Size of the digital file in megabytes
    public double Size { get; set; }
    // File extension or format (e.g., .exe, .pdf)
    public string FileType { get; set; }

    // Constructor with input validation and default fallbacks
    public DigitalProduct(string? name, double price, int stock, ProductCategory? category, double discount, double size, string? fileType)
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

        // Assign file size if valid
        if (size > 0)
            Size = size;

        // Set default file type if null
        FileType = fileType ?? "UnknownFileType";
    }

    // Applies a percentage discount to the product price
    public void ApplyDiscount()
    {
        Price = Math.Round(Price - Price * Discount / 100, 2);
    }
}