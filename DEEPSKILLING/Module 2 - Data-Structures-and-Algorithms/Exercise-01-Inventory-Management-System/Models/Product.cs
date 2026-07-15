namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise01InventoryManagementSystem.Models;

/// <summary>
/// Represents a product stored in the warehouse inventory.
/// </summary>
public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Quantity: {Quantity}, Price: {Price:F2}";
    }
}
