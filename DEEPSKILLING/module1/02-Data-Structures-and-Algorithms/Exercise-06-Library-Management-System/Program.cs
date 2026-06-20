using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise06LibraryManagementSystem.Models;
using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise06LibraryManagementSystem.Services;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise06LibraryManagementSystem;

public static class Program
{
    public static void Main()
    {
        var searchService = new BookSearchService();

        while (true)
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Linear Search by Title");
            Console.WriteLine("2. Binary Search by Title");
            Console.WriteLine("3. View Catalog");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    SearchBook(searchService, useBinarySearch: false);
                    break;
                case "2":
                    SearchBook(searchService, useBinarySearch: true);
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

    private static void SearchBook(BookSearchService searchService, bool useBinarySearch)
    {
        string title = ReadString("Enter book title to search: ");
        Book? book = useBinarySearch
            ? searchService.BinarySearchByTitle(title)
            : searchService.LinearSearchByTitle(title);

        if (book is null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        Console.WriteLine("Book found:");
        Console.WriteLine(book);
    }

    private static void DisplayCatalog(BookSearchService searchService)
    {
        IReadOnlyList<Book> books = searchService.GetAllBooks();

        Console.WriteLine("Sorted Book Catalog:");
        foreach (Book book in books)
        {
            Console.WriteLine(book);
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
