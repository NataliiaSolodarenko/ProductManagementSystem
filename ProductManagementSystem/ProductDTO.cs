// Data Transfer Object (DTO) used to deserialize product data from JSON.
public class ProductDTO
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public double Discount { get; set; }
    public double? Size { get; set; }
    public string? FileType { get; set; }
    public double? Weight { get; set; }
    public List<double>? Dimensions { get; set; }
    public string ProductType { get; set; }
}