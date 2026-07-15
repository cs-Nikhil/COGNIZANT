namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise04EmployeeManagementSystem.Models;

/// <summary>
/// Represents an employee record stored in an array.
/// </summary>
public class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: {Salary:F2}";
    }
}
