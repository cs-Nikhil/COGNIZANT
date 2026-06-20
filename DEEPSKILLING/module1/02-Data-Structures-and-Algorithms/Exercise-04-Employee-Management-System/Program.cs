using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise04EmployeeManagementSystem.Models;
using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise04EmployeeManagementSystem.Services;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise04EmployeeManagementSystem;

public static class Program
{
    public static void Main()
    {
        var employeeManager = new EmployeeManager(capacity: 10);

        while (true)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Search Employee");
            Console.WriteLine("3. View All Employees");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddEmployee(employeeManager);
                    break;
                case "2":
                    SearchEmployee(employeeManager);
                    break;
                case "3":
                    TraverseEmployees(employeeManager);
                    break;
                case "4":
                    DeleteEmployee(employeeManager);
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

    private static void AddEmployee(EmployeeManager employeeManager)
    {
        Employee employee = ReadEmployeeDetails();

        if (employeeManager.AddEmployee(employee))
        {
            Console.WriteLine("Employee added successfully.");
        }
        else
        {
            Console.WriteLine("Employee could not be added. The array may be full or the ID already exists.");
        }
    }

    private static void SearchEmployee(EmployeeManager employeeManager)
    {
        int employeeId = ReadInt("Enter employee ID to search: ");
        Employee? employee = employeeManager.SearchEmployee(employeeId);

        if (employee is null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.WriteLine("Employee found:");
        Console.WriteLine(employee);
    }

    private static void TraverseEmployees(EmployeeManager employeeManager)
    {
        IReadOnlyList<Employee> employees = employeeManager.TraverseEmployees();

        if (employees.Count == 0)
        {
            Console.WriteLine("No employee records available.");
            return;
        }

        Console.WriteLine("Employee Records:");
        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee);
        }
    }

    private static void DeleteEmployee(EmployeeManager employeeManager)
    {
        int employeeId = ReadInt("Enter employee ID to delete: ");

        if (employeeManager.DeleteEmployee(employeeId))
        {
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found. Delete failed.");
        }
    }

    private static Employee ReadEmployeeDetails()
    {
        int employeeId = ReadInt("Enter employee ID: ");
        string name = ReadString("Enter name: ");
        string position = ReadString("Enter position: ");
        decimal salary = ReadDecimal("Enter salary: ");

        return new Employee
        {
            EmployeeId = employeeId,
            Name = name,
            Position = position,
            Salary = salary
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

    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                return value;
            }

            Console.WriteLine("Invalid amount. Please enter a valid decimal value.");
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
