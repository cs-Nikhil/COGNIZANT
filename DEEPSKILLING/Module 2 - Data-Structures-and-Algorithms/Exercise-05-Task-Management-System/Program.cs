using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem.Models;
using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem.Services;
using TaskItem = DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem.Models.Task;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem;

public static class Program
{
    public static void Main()
    {
        var taskManager = new TaskLinkedListManager();

        while (true)
        {
            Console.WriteLine("Task Management System");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Search Task");
            Console.WriteLine("3. View All Tasks");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddTask(taskManager);
                    break;
                case "2":
                    SearchTask(taskManager);
                    break;
                case "3":
                    TraverseTasks(taskManager);
                    break;
                case "4":
                    DeleteTask(taskManager);
                    break;
                case "5":
                    Console.WriteLine("Exiting the application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void AddTask(TaskLinkedListManager taskManager)
    {
        TaskItem task = ReadTaskDetails();
        taskManager.AddTask(task);
        Console.WriteLine("Task added successfully.");
    }

    private static void SearchTask(TaskLinkedListManager taskManager)
    {
        int taskId = ReadInt("Enter task ID to search: ");
        TaskItem? task = taskManager.SearchTask(taskId);

        if (task is null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        Console.WriteLine("Task found:");
        Console.WriteLine(task);
    }

    private static void TraverseTasks(TaskLinkedListManager taskManager)
    {
        IReadOnlyList<TaskItem> tasks = taskManager.TraverseTasks();

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("Task List:");
        foreach (TaskItem task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    private static void DeleteTask(TaskLinkedListManager taskManager)
    {
        int taskId = ReadInt("Enter task ID to delete: ");

        if (taskManager.DeleteTask(taskId))
        {
            Console.WriteLine("Task deleted successfully.");
        }
        else
        {
            Console.WriteLine("Task not found. Delete failed.");
        }
    }

    private static TaskItem ReadTaskDetails()
    {
        int taskId = ReadInt("Enter task ID: ");
        string taskName = ReadString("Enter task name: ");
        string status = ReadString("Enter status: ");

        return new TaskItem
        {
            TaskId = taskId,
            TaskName = taskName,
            Status = status
        };
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            Console.WriteLine("Invalid number. Please enter a valid integer.");
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
