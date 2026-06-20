namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise03SortingCustomerOrders.Models;

/// <summary>
/// Represents a customer order that can be sorted by total price.
/// </summary>
public class Order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public decimal TotalPrice { get; set; }

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {CustomerName}, Total Price: {TotalPrice:F2}";
    }
}
