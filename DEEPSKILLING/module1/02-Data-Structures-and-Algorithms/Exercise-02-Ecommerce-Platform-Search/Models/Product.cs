namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise02EcommercePlatformSearch.Models;

/// <summary>
/// Represents a product that can be searched in the e-commerce catalog.
/// </summary>
public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}
