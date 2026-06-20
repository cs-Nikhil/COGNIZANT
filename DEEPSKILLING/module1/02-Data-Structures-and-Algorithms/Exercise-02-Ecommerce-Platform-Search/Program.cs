using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise02EcommercePlatformSearch.Models;
using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise02EcommercePlatformSearch.Services;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise02EcommercePlatformSearch;

public static class Program
{
    public static void Main()
    {
        var searchService = new ProductSearchService();

        while (true)
        {
            Console.WriteLine("E-commerce Platform Search");
            Console.WriteLine("1. Linear Search by Product Name");
            Console.WriteLine("2. Binary Search by Product Name");
            Console.WriteLine("3. View Catalog");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    SearchProduct(searchService, useBinarySearch: false);
                    break;
                case "2":
                    SearchProduct(searchService, useBinarySearch: true);
                    break;
                case "3":
                    DisplayCatalog(searchService);
                    break;
                case "4":
                    Console.WriteLine("Exiting the application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void SearchProduct(ProductSearchService searchService, bool useBinarySearch)
    {
        string productName = ReadString("Enter product name to search: ");
        Product? product = useBinarySearch
            ? searchService.BinarySearchByName(productName)
            : searchService.LinearSearchByName(productName);

        if (product is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.WriteLine("Product found:");
        Console.WriteLine(product);
    }

    private static void DisplayCatalog(ProductSearchService searchService)
    {
        IReadOnlyList<Product> products = searchService.GetAllProducts();

        Console.WriteLine("Sorted Product Catalog:");
        foreach (Product product in products)
        {
            Console.WriteLine(product);
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
