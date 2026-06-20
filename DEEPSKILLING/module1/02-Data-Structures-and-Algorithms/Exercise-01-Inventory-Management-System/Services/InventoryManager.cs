using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise01InventoryManagementSystem.Models;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise01InventoryManagementSystem.Services;

/// <summary>
/// Manages inventory operations using a dictionary for fast lookups by ProductId.
/// </summary>
public class InventoryManager
{
    private readonly Dictionary<int, Product> _products = new();

    public bool AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (_products.ContainsKey(product.ProductId))
        {
            return false;
        }

        _products[product.ProductId] = product;
        return true;
    }

    public bool UpdateProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (!_products.ContainsKey(product.ProductId))
        {
            return false;
        }

        _products[product.ProductId] = product;
        return true;
    }

    public bool DeleteProduct(int productId)
    {
        return _products.Remove(productId);
    }

    public IReadOnlyCollection<Product> GetAllProducts()
    {
        return _products.Values
            .OrderBy(product => product.ProductId)
            .ToList();
    }

    public bool TryGetProduct(int productId, out Product? product)
    {
        return _products.TryGetValue(productId, out product);
    }
}
