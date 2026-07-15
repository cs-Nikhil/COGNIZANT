# Exercise 6: Library Management System

## Scenario
You are developing a library management system where users can search for books by title or author.

## Objective
Build a C# console application that demonstrates linear search and binary search for books by title, then compare their performance and usage scenarios.

## Search Algorithms
### Linear Search
Linear search checks each element one by one until the target is found or the list ends.

### Binary Search
Binary search works on sorted data and repeatedly halves the search range.

## Book Model
The `Book` class stores:
- `BookId`
- `Title`
- `Author`

## Implementation
This project implements:
- Linear search to find books by title
- Binary search to find books by title on a sorted list

The catalog is stored in an unsorted array for linear search and a sorted array for binary search.

## Project Structure
```text
Module-01/
└── 02-Data-Structures-and-Algorithms/
    └── Exercise-06-Library-Management-System/
        ├── LibraryManagementSystem.csproj
        ├── Program.cs
        ├── Models/
        │   └── Book.cs
        └── Services/
            └── BookSearchService.cs
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
Clean Code
4
```

## Sample Output
```text
Library Management System
1. Linear Search by Title
2. Binary Search by Title
3. View Catalog
4. Exit
Enter your choice:

Enter book title to search: Clean Code
Book found:
ID: 302, Title: Clean Code, Author: Robert C. Martin
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

## When to Use Each Algorithm
### Use Linear Search When
- The dataset is small
- The list is unsorted
- Simplicity is more important than speed

### Use Binary Search When
- The dataset is sorted
- Search operations are frequent
- You need faster lookup on large datasets

## Explanation
Linear search is straightforward and works on any list, but it becomes slow as the dataset grows. Binary search is much faster, but only if the data is sorted. For a library system, binary search is ideal when the catalog is maintained in sorted order by title.
