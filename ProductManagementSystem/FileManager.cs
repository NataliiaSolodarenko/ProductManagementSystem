using System.Text.Json;

// Provides methods for saving and loading data (e.g., products, customers) to and from JSON files.
public class FileManager
{
    // Loads product data from a JSON file and converts DTOs into Product objects.
    // Supports both DigitalProduct and PhysicalProduct types.
    public List<Product> LoadProducts(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return new List<Product>();

            string file = File.ReadAllText(filePath);
            var productDtos = JsonSerializer.Deserialize<List<ProductDTO>>(file);

            if (productDtos == null)
                return new List<Product>();

            List<Product> products = productDtos.Select<ProductDTO, Product>(p =>
            {
                ProductCategory category = Enum.TryParse<ProductCategory>(p.Category, out var parsedCategory)
                    ? parsedCategory : ProductCategory.Other;

                if (p.ProductType == "Digital")
                    return new DigitalProduct(p.Name, p.Price, p.Stock, category, p.Discount, p.Size ?? 0, p.FileType);
                else
                    return new PhysicalProduct(p.Name, p.Price, p.Stock, category, p.Discount, p.Weight ?? 0, p.Dimensions);
            }).ToList();

            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading list of products: {ex.Message}");
            return new List<Product>();
        }
    }

    // Saves product data to a JSON file by converting Product objects to ProductDTOs.
    public Action<List<Product>, string> SaveProducts = (products, filePath) =>
    {
        var productDtos = products.Select(p => new ProductDTO
        {
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            Category = p.Category.ToString(),
            Discount = p.Discount,
            ProductType = p is DigitalProduct ? "Digital" : "Physical",
            Size = (p is DigitalProduct digital1) ? digital1.Size : null,
            FileType = (p is DigitalProduct digital2) ? digital2.FileType : null,
            Weight = (p is PhysicalProduct physical1) ? physical1.Weight : null,
            Dimensions = (p is PhysicalProduct physical2) ? physical2.Dimensions : null,
        }).ToList();

        string file = JsonSerializer.Serialize(productDtos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, file);
        Console.WriteLine($"File have been saved! (Path: {filePath})");
    };

    // Loads customer data from a JSON file.
    public List<Customer> LoadCustomers(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return new List<Customer>();

            string file = File.ReadAllText(filePath);
            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(file) ?? new List<Customer>();
            return customers;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading list of customers: {ex.Message}");
            return new List<Customer>();
        }
    }

    // Saves customer data to a JSON file using JSON serialization.
    public Action<List<Customer>, string> SaveCustomers = (customers, filePath) =>
    {
        string file = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, file);
        Console.WriteLine($"File have been saved! (Path: {filePath})");
    };
}