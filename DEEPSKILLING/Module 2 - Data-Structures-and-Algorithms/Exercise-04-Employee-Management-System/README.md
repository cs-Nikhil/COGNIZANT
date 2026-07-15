# Exercise 4: Employee Management System

## Scenario
You are developing an employee management system for a company. Efficiently managing employee records is crucial.

## Objective
Build a C# console application that stores employee records in an array and supports add, search, traverse, and delete operations.

## Array Representation in Memory
Arrays store elements in contiguous memory locations. That means each element is placed directly after the previous one, which makes indexed access fast.

### Advantages
- Fast access by index
- Simple structure
- Efficient traversal
- Low memory overhead compared to some dynamic structures

## Employee Model
The `Employee` class stores:
- `EmployeeId`
- `Name`
- `Position`
- `Salary`

## Implementation
This project uses a fixed-size array to store employee records.

It supports:
- Add employee
- Search employee by ID
- Traverse all employees
- Delete employee by ID

When an employee is deleted, the remaining records are shifted left to keep the array compact.

## Project Structure
```text
Module-01/
└── 02-Data-Structures-and-Algorithms/
    └── Exercise-04-Employee-Management-System/
        ├── EmployeeManagementSystem.csproj
        ├── Program.cs
        ├── Models/
        │   └── Employee.cs
        └── Services/
            └── EmployeeManager.cs
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
Anita
Developer
65000
3
2
101
4
5
```

## Sample Output
```text
Employee Management System
1. Add Employee
2. Search Employee
3. View All Employees
4. Delete Employee
5. Exit
Enter your choice:

Employee added successfully.

Employee Records:
ID: 101, Name: Anita, Position: Developer, Salary: 65000.00

Employee found:
ID: 101, Name: Anita, Position: Developer, Salary: 65000.00
```

## Time Complexity
- Add Employee: `O(1)` if space is available, but `O(n)` if checking for duplicate IDs
- Search Employee: `O(n)`
- Traverse Employees: `O(n)`
- Delete Employee: `O(n)` because shifting may be required

## Space Complexity
- `O(n)` for storing `n` employee records

## Limitations of Arrays
- Fixed size, so resizing is not automatic
- Searching is linear unless additional indexing is used
- Deletion requires shifting elements
- Insertions in the middle are inefficient

## When to Use Arrays
Arrays are useful when:
- The size of the data is known in advance
- Fast indexed access is important
- The structure is simple and memory-efficient storage is preferred

## Explanation
Arrays are a good fit for this exercise because they clearly demonstrate contiguous storage and linear operations. The console app uses a fixed-size array to manage records and shows how search, traversal, and deletion work in a straightforward way.
