using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise04EmployeeManagementSystem.Models;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise04EmployeeManagementSystem.Services;

/// <summary>
/// Manages employee records using a fixed-size array.
/// </summary>
public class EmployeeManager
{
    private readonly Employee?[] _employees;
    private int _count;

    public EmployeeManager(int capacity = 10)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
        }

        _employees = new Employee?[capacity];
        _count = 0;
    }

    public bool AddEmployee(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        if (_count >= _employees.Length)
        {
            return false;
        }

        if (SearchEmployee(employee.EmployeeId) is not null)
        {
            return false;
        }

        _employees[_count] = employee;
        _count++;
        return true;
    }

    public Employee? SearchEmployee(int employeeId)
    {
        for (int index = 0; index < _count; index++)
        {
            Employee? currentEmployee = _employees[index];

            if (currentEmployee is not null && currentEmployee.EmployeeId == employeeId)
            {
                return currentEmployee;
            }
        }

        return null;
    }

    public IReadOnlyList<Employee> TraverseEmployees()
    {
        List<Employee> employees = new();

        for (int index = 0; index < _count; index++)
        {
            if (_employees[index] is Employee employee)
            {
                employees.Add(employee);
            }
        }

        return employees;
    }

    public bool DeleteEmployee(int employeeId)
    {
        int indexToDelete = -1;

        for (int index = 0; index < _count; index++)
        {
            if (_employees[index]?.EmployeeId == employeeId)
            {
                indexToDelete = index;
                break;
            }
        }

        if (indexToDelete == -1)
        {
            return false;
        }

        for (int index = indexToDelete; index < _count - 1; index++)
        {
            _employees[index] = _employees[index + 1];
        }

        _employees[_count - 1] = null;
        _count--;
        return true;
    }
}
