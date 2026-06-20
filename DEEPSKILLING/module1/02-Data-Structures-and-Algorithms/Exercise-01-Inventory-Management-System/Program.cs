using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise01InventoryManagementSystem.Models;
using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise01InventoryManagementSystem.Services;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise01InventoryManagementSystem;

public static class Program
{
    public static void Main()
    {
        var inventoryManager = new InventoryManager();

        while (true)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. View Products");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddProduct(inventoryManager);
                    break;
                case "2":
                    UpdateProduct(inventoryManager);
                    break;
                case "3":
                    DeleteProduct(inventoryManager);
                    break;
                case "4":
                    DisplayProducts(inventoryManager);
                    break;
                case "5":
                    Console.WriteLine("Exiting the application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void AddProduct(InventoryManager inventoryManager)
    {
        Product product = ReadProductDetails();

        if (inventoryManager.AddProduct(product))
        {
            Console.WriteLine("Product added successfully.");
        }
        else
        {
            Console.WriteLine("A product with the same ID already exists.");
        }
    }

    private static void UpdateProduct(InventoryManager inventoryManager)
    {
        Product product = ReadProductDetails();

        if (inventoryManager.UpdateProduct(product))
        {
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found. Update failed.");
        }
    }

    private static void DeleteProduct(InventoryManager inventoryManager)
    {
        int productId = ReadInt("Enter product ID to delete: ");

        if (inventoryManager.DeleteProduct(productId))
        {
            Console.WriteLine("Product deleted successfully.");
        }
        else
        {
            Console.WriteLine("Product not found. Delete failed.");
        }
    }

    private static void DisplayProducts(InventoryManager inventoryManager)
    {
        IReadOnlyCollection<Product> products = inventoryManager.GetAllProducts();

        if (products.Count == 0)
        {
            Console.WriteLine("No products found in inventory.");
            return;
        }

        Console.WriteLine("Current Inventory:");
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }

    private static Product ReadProductDetails()
    {
        int productId = ReadInt("Enter product ID: ");
        string productName = ReadString("Enter product name: ");
        int quantity = ReadInt("Enter quantity: ");
        decimal price = ReadDecimal("Enter price: ");

        return new Product
        {
            ProductId = productId,
            ProductName = productName,
            Quantity = quantity,
            Price = price
        };
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            Console.WriteLine("Invalid number. Please enter a valid integer.");
        }
    }

    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                return value;
            }

            Console.WriteLine("Invalid amount. Please enter a valid decimal value.");
        }
    }

    private static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }

            Console.WriteLine("Input cannot be empty.");
        }
    }
}
