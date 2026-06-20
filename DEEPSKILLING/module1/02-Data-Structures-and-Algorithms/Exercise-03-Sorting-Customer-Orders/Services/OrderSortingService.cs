using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise03SortingCustomerOrders.Models;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise03SortingCustomerOrders.Services;

/// <summary>
/// Provides bubble sort and quick sort implementations for order data.
/// </summary>
public class OrderSortingService
{
    private readonly Order[] _orders;

    public OrderSortingService()
    {
        _orders = new[]
        {
            new Order { OrderId = 2005, CustomerName = "Aarav", TotalPrice = 849.50m },
            new Order { OrderId = 2001, CustomerName = "Meera", TotalPrice = 2499.00m },
            new Order { OrderId = 2003, CustomerName = "Rohan", TotalPrice = 1299.75m },
            new Order { OrderId = 2002, CustomerName = "Priya", TotalPrice = 499.99m },
            new Order { OrderId = 2004, CustomerName = "Kabir", TotalPrice = 1899.00m }
        };
    }

    public IReadOnlyList<Order> GetOriginalOrders()
    {
        return _orders.ToArray();
    }

    public IReadOnlyList<Order> GetOrdersSortedByBubbleSort()
    {
        Order[] sortedOrders = _orders.ToArray();
        BubbleSort(sortedOrders);
        return sortedOrders;
    }

    public IReadOnlyList<Order> GetOrdersSortedByQuickSort()
    {
        Order[] sortedOrders = _orders.ToArray();
        QuickSort(sortedOrders, 0, sortedOrders.Length - 1);
        return sortedOrders;
    }

    private static void BubbleSort(Order[] orders)
    {
        for (int pass = 0; pass < orders.Length - 1; pass++)
        {
            bool hasSwapped = false;

            for (int index = 0; index < orders.Length - pass - 1; index++)
            {
                if (orders[index].TotalPrice > orders[index + 1].TotalPrice)
                {
                    (orders[index], orders[index + 1]) = (orders[index + 1], orders[index]);
                    hasSwapped = true;
                }
            }

            if (!hasSwapped)
            {
                break;
            }
        }
    }

    private static void QuickSort(Order[] orders, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int pivotIndex = Partition(orders, left, right);
        QuickSort(orders, left, pivotIndex - 1);
        QuickSort(orders, pivotIndex + 1, right);
    }

    private static int Partition(Order[] orders, int left, int right)
    {
        decimal pivotValue = orders[right].TotalPrice;
        int smallerIndex = left - 1;

        for (int currentIndex = left; currentIndex < right; currentIndex++)
        {
            if (orders[currentIndex].TotalPrice <= pivotValue)
            {
                smallerIndex++;
                (orders[smallerIndex], orders[currentIndex]) = (orders[currentIndex], orders[smallerIndex]);
            }
        }

        (orders[smallerIndex + 1], orders[right]) = (orders[right], orders[smallerIndex + 1]);
        return smallerIndex + 1;
    }
}
