# Exercise 2: E-commerce Platform Search Function

## Scenario
You are working on the search functionality of an e-commerce platform. The search needs to be optimized for fast performance.

## Objective
Build a console application that demonstrates linear search and binary search for product lookup, and analyze their performance using Big O notation.

## Big O Notation
Big O notation describes how an algorithm's runtime or memory usage grows as the input size increases.

It helps us compare algorithms by focusing on scalability instead of hardware or implementation details.

### Search Scenarios
- Best case: the item is found immediately
- Average case: the item is found after checking a typical number of elements
- Worst case: the item is found last or not found at all

## Product Model
The `Product` class stores:
- `ProductId`
- `ProductName`
- `Category`

## Search Algorithms
### Linear Search
Linear search checks each item one by one until the target is found.

### Binary Search
Binary search works on a sorted array and repeatedly halves the search space.

## Project Structure
```text
Module-01/
└── 02-Data-Structures-and-Algorithms/
    └── Exercise-02-Ecommerce-Platform-Search/
        ├── EcommercePlatformSearch.csproj
        ├── Program.cs
        ├── Models/
        │   └── Product.cs
        └── Services/
            └── ProductSearchService.cs
```

## How to Run
1. Open the project folder in terminal.
2. Run:
```bash
dotnet run
```

## Sample Input
```text
2
Laptop
4
```

## Sample Output
```text
E-commerce Platform Search
1. Linear Search by Product Name
2. Binary Search by Product Name
3. View Catalog
4. Exit
Enter your choice:

Enter product name to search: Laptop
Product found:
ID: 105, Name: Laptop, Category: Computers
```

## Time Complexity
- Linear Search:
  - Best: `O(1)`
  - Average: `O(n)`
  - Worst: `O(n)`
- Binary Search:
  - Best: `O(1)`
  - Average: `O(log n)`
  - Worst: `O(log n)`

## Space Complexity
- Linear Search: `O(1)`
- Binary Search: `O(1)`

## Which Algorithm Is More Suitable?
Binary search is more suitable for a platform that performs repeated exact-match lookups on sorted data because it is significantly faster for large catalogs.

Linear search is useful when the data is unsorted, frequently changing, or when the catalog is small enough that simplicity matters more than performance.

In a real e-commerce system, binary search or indexed storage is a better choice for performance-sensitive search operations.

## Explanation
This project stores one catalog as an unsorted array for linear search and another as a sorted array for binary search. The console application lets the user test both algorithms and compare their behavior on the same product data.
