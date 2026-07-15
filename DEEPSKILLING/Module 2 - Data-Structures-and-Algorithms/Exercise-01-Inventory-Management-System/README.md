# Exercise 1: Inventory Management System

## Scenario
You are developing an inventory management system for a warehouse. Efficient data storage and retrieval are crucial.

## Objective
Build a console application that can add, update, delete, and view products in inventory while demonstrating why data structures and algorithms matter for large-scale inventory handling.

## Why Data Structures and Algorithms Matter
Large inventories can contain thousands of products. Without the right data structure, each lookup may require scanning every item, which becomes slow as the inventory grows.

Data structures and algorithms help us:
- Store products efficiently
- Retrieve products quickly by key
- Keep code scalable and maintainable

## Suitable Data Structures
For this exercise, a `Dictionary<int, Product>` is used.

### Why Dictionary?
- Fast lookup by `ProductId`
- Efficient add, update, and delete operations
- Clear key-value relationship between product ID and product details

### Alternatives
- `List<Product>` or `ArrayList`: simple, but lookup becomes slower because each search may require a full scan
- `Dictionary<int, Product>`: better for frequent search, update, and delete by ID

## Project Structure
```text
Module-01/
└── 02-Data-Structures-and-Algorithms/
    └── Exercise-01-Inventory-Management-System/
        ├── InventoryManagementSystem.csproj
        ├── Program.cs
        ├── Models/
        │   └── Product.cs
        └── Services/
            └── InventoryManager.cs
```

## How to Run
1. Open the project folder in terminal.
2. Run:
```bash
dotnet run
```

## Sample Input
```text
1
101
Keyboard
25
750.50
4
5
```

## Sample Output
```text
Inventory Management System
1. Add Product
2. Update Product
3. Delete Product
4. View Products
5. Exit
Enter your choice:

Product added successfully.

Current Inventory:
ID: 101, Name: Keyboard, Quantity: 25, Price: 750.50
```

## Time Complexity
- Add Product: `O(1)` average
- Update Product: `O(1)` average
- Delete Product: `O(1)` average
- View Products: `O(n)`

## Space Complexity
- `O(n)` for storing `n` products in the dictionary

## Optimization Discussion
This implementation is already optimized for direct lookup using `ProductId`.

Possible improvements:
- Use input validation to prevent invalid product data
- Add persistence using a file or database for long-term storage
- If products must be searched by name often, maintain an additional index for name-based lookup

## Explanation
The application stores products in a dictionary where the product ID is the key and the product object is the value. This makes add, update, and delete operations efficient. The console app provides a simple interactive menu to demonstrate inventory management operations.
