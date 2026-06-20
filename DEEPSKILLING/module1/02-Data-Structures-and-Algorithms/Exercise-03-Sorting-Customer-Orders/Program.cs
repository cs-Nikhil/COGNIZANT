using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise03SortingCustomerOrders.Models;
using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise03SortingCustomerOrders.Services;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise03SortingCustomerOrders;

public static class Program
{
    public static void Main()
    {
        var sortingService = new OrderSortingService();

        while (true)
        {
            Console.WriteLine("Sorting Customer Orders");
            Console.WriteLine("1. View Original Orders");
            Console.WriteLine("2. Sort Using Bubble Sort");
            Console.WriteLine("3. Sort Using Quick Sort");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    DisplayOrders("Original Orders", sortingService.GetOriginalOrders());
                    break;
                case "2":
                    DisplayOrders("Orders Sorted by Bubble Sort", sortingService.GetOrdersSortedByBubbleSort());
                    break;
                case "3":
                    DisplayOrders("Orders Sorted by Quick Sort", sortingService.GetOrdersSortedByQuickSort());
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

    private static void DisplayOrders(string title, IReadOnlyList<Order> orders)
    {
        Console.WriteLine(title);

        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }
    }
}
