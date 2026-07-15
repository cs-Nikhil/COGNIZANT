# Exercise 3: Sorting Customer Orders

## Scenario
You are tasked with sorting customer orders by their total price on an e-commerce platform. This helps in prioritizing high-value orders.

## Objective
Build a C# console application that demonstrates Bubble Sort and Quick Sort, then compare their performance and explain why Quick Sort is generally preferred.

## Sorting Algorithms
### Bubble Sort
Bubble Sort repeatedly compares adjacent elements and swaps them if they are in the wrong order.

### Insertion Sort
Insertion Sort builds a sorted list one element at a time by inserting each new element into its correct position.

### Quick Sort
Quick Sort chooses a pivot and partitions the list into smaller and larger elements before sorting each partition recursively.

### Merge Sort
Merge Sort divides the list into halves, sorts each half, and merges the results.

## Order Model
The `Order` class stores:
- `OrderId`
- `CustomerName`
- `TotalPrice`

## Implementation
This project implements:
- Bubble Sort for sorting orders by `TotalPrice`
- Quick Sort for sorting orders by `TotalPrice`

The orders are stored in an array, and each algorithm sorts a copy of the same dataset so the results can be compared fairly.

## Project Structure
```text
Module-01/
└── 02-Data-Structures-and-Algorithms/
    └── Exercise-03-Sorting-Customer-Orders/
        ├── SortingCustomerOrders.csproj
        ├── Program.cs
        ├── Models/
        │   └── Order.cs
        └── Services/
            └── OrderSortingService.cs
```

## How to Run
1. Open the project folder in terminal.
2. Run:
```bash
dotnet run
```

## Sample Input
```text
3
4
```

## Sample Output
```text
Sorting Customer Orders
1. View Original Orders
2. Sort Using Bubble Sort
3. Sort Using Quick Sort
4. Exit
Enter your choice:

Orders Sorted by Quick Sort
Order ID: 2002, Customer: Priya, Total Price: 499.99
Order ID: 2005, Customer: Aarav, Total Price: 849.50
Order ID: 2003, Customer: Rohan, Total Price: 1299.75
Order ID: 2004, Customer: Kabir, Total Price: 1899.00
Order ID: 2001, Customer: Meera, Total Price: 2499.00
```

## Time Complexity
### Bubble Sort
- Best: `O(n)` if optimized with early exit and the array is already sorted
- Average: `O(n^2)`
- Worst: `O(n^2)`

### Quick Sort
- Best: `O(n log n)`
- Average: `O(n log n)`
- Worst: `O(n^2)`

## Space Complexity
- Bubble Sort: `O(1)`
- Quick Sort: `O(log n)` average due to recursion stack

## Why Quick Sort Is Preferred
Quick Sort is generally preferred because it performs much better on large datasets in most real-world scenarios.

Compared to Bubble Sort:
- It does far fewer comparisons and swaps on average
- It scales better as the number of orders grows
- It is more practical for performance-sensitive applications

Bubble Sort is simple to understand, but it becomes inefficient very quickly for larger lists.

## Explanation
The application stores customer orders in an array and offers two sorting options. Bubble Sort shows the basic comparison-and-swap approach, while Quick Sort demonstrates a more efficient divide-and-conquer strategy.
