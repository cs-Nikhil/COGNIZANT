# Exercise 5: Task Management System

## Scenario
You are developing a task management system where tasks need to be added, deleted, and traversed efficiently.

## Objective
Build a C# console application that uses a singly linked list to manage tasks and demonstrates the add, search, traverse, and delete operations.

## Linked List Types
### Singly Linked List
A singly linked list stores each node with data and a reference to the next node only.

### Doubly Linked List
A doubly linked list stores each node with references to both the next and previous nodes.

## Task Model
The `Task` class stores:
- `TaskId`
- `TaskName`
- `Status`

## Implementation
This project uses a singly linked list to manage task records.

Supported operations:
- Add task
- Search task by ID
- Traverse all tasks
- Delete task by ID

## Project Structure
```text
Module-01/
└── 02-Data-Structures-and-Algorithms/
    └── Exercise-05-Task-Management-System/
        ├── TaskManagementSystem.csproj
        ├── Program.cs
        ├── Models/
        │   └── Task.cs
        └── Services/
            └── TaskLinkedListManager.cs
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
501
Design UI
Pending
3
2
501
4
5
```

## Sample Output
```text
Task Management System
1. Add Task
2. Search Task
3. View All Tasks
4. Delete Task
5. Exit
Enter your choice:

Task added successfully.

Task List:
ID: 501, Name: Design UI, Status: Pending

Task found:
ID: 501, Name: Design UI, Status: Pending
```

## Time Complexity
- Add Task: `O(1)` when inserting at the head
- Search Task: `O(n)`
- Traverse Tasks: `O(n)`
- Delete Task: `O(n)`

## Space Complexity
- `O(n)` for storing `n` tasks

## Advantages of Linked Lists Over Arrays
- Dynamic size, so the list can grow or shrink easily
- Insertion and deletion are easier when the node location is known
- No need for contiguous memory allocation

## Explanation
Linked lists are useful when data changes frequently. Compared with arrays, they are more flexible for dynamic insertions and deletions, though searching still requires linear traversal.
