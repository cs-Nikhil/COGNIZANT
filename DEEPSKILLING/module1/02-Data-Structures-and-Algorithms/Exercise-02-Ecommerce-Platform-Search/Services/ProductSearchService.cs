using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise02EcommercePlatformSearch.Models;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise02EcommercePlatformSearch.Services;

/// <summary>
/// Provides linear search and binary search over a product catalog.
/// </summary>
public class ProductSearchService
{
    private readonly Product[] _linearSearchCatalog;
    private readonly Product[] _binarySearchCatalog;

    public ProductSearchService()
    {
        _linearSearchCatalog = new[]
        {
            new Product { ProductId = 103, ProductName = "Mouse", Category = "Accessories" },
            new Product { ProductId = 101, ProductName = "Keyboard", Category = "Accessories" },
            new Product { ProductId = 106, ProductName = "Webcam", Category = "Accessories" },
            new Product { ProductId = 102, ProductName = "Monitor", Category = "Display" },
            new Product { ProductId = 105, ProductName = "Laptop", Category = "Computers" },
            new Product { ProductId = 104, ProductName = "Headphones", Category = "Audio" }
        };

        _binarySearchCatalog = _linearSearchCatalog
            .OrderBy(product => product.ProductName, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    public IReadOnlyList<Product> GetAllProducts()
    {
        return _binarySearchCatalog;
    }

    public Product? LinearSearchByName(string productName)
    {
        for (int index = 0; index < _linearSearchCatalog.Length; index++)
        {
            Product currentProduct = _linearSearchCatalog[index];

            if (string.Equals(currentProduct.ProductName, productName, StringComparison.OrdinalIgnoreCase))
            {
                return currentProduct;
            }
        }

        return null;
    }

    public Product? BinarySearchByName(string productName)
    {
        int left = 0;
        int right = _binarySearchCatalog.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            Product currentProduct = _binarySearchCatalog[middle];
            int comparison = string.Compare(currentProduct.ProductName, productName, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
            {
                return currentProduct;
            }

            if (comparison < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return null;
    }
}
