using System;

// Main entry point for the application.
// Loads products and customers from JSON files, applies discounts, and displays filtered results.
class Program
{
    static void Main()
    {
        FileManager fm = new FileManager();
        string productFilePath = "ListOfProducts.json";
        List<Product> products = fm.LoadProducts(productFilePath);
        if (products.Count == 0)
        {
            Console.WriteLine("The list of products is empty!");
            return;
        }

        string customerFilePath = "ListOfCustomers.json";
        List<Customer> customers = fm.LoadCustomers(customerFilePath);
        if (customers.Count == 0)
        {
            Console.WriteLine("The list of customers is empty!");
            return;
        }

        Console.WriteLine("\nAll products before appling discount:");
        ShowAllProducts(products);

        ApplyDiscountForAll(products);

        Console.WriteLine("\nAll products after appling discount:");
        ShowAllProducts(products);

        // Simulate a product being sold
        products[5].SellProduct(7);

        Console.WriteLine("\nAll products under Toys category:");
        ShowAllProducts(SortProductsBySelectedCategory(products, ProductCategory.Toys));

        Console.WriteLine("\nAll products under Toys category with discount:");
        ShowAllProducts(SortProductsByHavingDiscount(SortProductsBySelectedCategory(products, ProductCategory.Toys)));

        Console.WriteLine("\nAll customers:");
        ShowAllCustomers(customers);

        Console.WriteLine("\nAll customers sorted by name:");
        ShowAllCustomers(SortCustomersByName(customers));

        string sortedCustomersFilePath = "SortedListOfCustomers.json";
        fm.SaveCustomers(SortCustomersByName(customers), sortedCustomersFilePath);

        string sortedProductsFilePath = "SortedListOfProducts.json";
        fm.SaveProducts(SortProductsByHavingDiscount(products), sortedProductsFilePath);
    }

    // Displays product information for a given list of products.
    // Supports both physical and digital products.
    public static Action<List<Product>> ShowAllProducts = products =>
    {
        foreach (dynamic p in products)
            if (p is PhysicalProduct)
                Console.WriteLine($"{p.Name} - ₴{p.Price} (in stock: {p.Stock}, {p.Weight} kg weight, dimensions: {p.Dimensions[0]}x{p.Dimensions[1]}x{p.Dimensions[2]})");
            else if (p is DigitalProduct)
                Console.WriteLine($"{p.Name} - ₴{p.Price} (in stock: {p.Stock}, {p.Size} mb, file type: {p.FileType})");
    };

    // Displays customer information (name and email).
    public static Action<List<Customer>> ShowAllCustomers = customers =>
    {
        foreach (var c in customers)
            Console.WriteLine($"{c.Name} - email: {c.Email}");
    };

    // Applies a discount to all products that implement IDiscountable.
    public static Action<List<Product>> ApplyDiscountForAll = products =>
    {
        Console.WriteLine("\nDiscounts have been applied!");
        foreach (IDiscountable p in products)
            p.ApplyDiscount();
    };

    // Filters products by selected category and returns a new list.
    public static Func<List<Product>, ProductCategory, List<Product>> SortProductsBySelectedCategory = (products, category) =>
    {
        return products.Where(p => p.Category == category).ToList();
    };

    // Filters products that have any discount applied (Discount > 0).
    public static Func<List<Product>, List<Product>> SortProductsByHavingDiscount = (products) =>
    {
        return products.Where(p => p.Discount > 0).ToList();
    };

    // Sorts the list of customers in ascending alphabetical order by name.
    public static Func<List<Customer>, List<Customer>> SortCustomersByName = (customers) =>
    {
        return customers.OrderBy(c => c.Name).ToList();
    };

}

