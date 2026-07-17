namespace CollectionsLib;

public sealed class Employee : IEquatable<Employee>
{
    public int EmployeeId { get; }

    public string Name { get; }

    public DateTime JoinedOn { get; }

    public Employee(int employeeId, string name, DateTime joinedOn)
    {
        EmployeeId = employeeId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        JoinedOn = joinedOn;
    }

    public bool Equals(Employee? other)
    {
        if (other is null)
        {
            return false;
        }

        return EmployeeId == other.EmployeeId
               && string.Equals(Name, other.Name, StringComparison.Ordinal)
               && JoinedOn == other.JoinedOn;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Employee);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EmployeeId, Name, JoinedOn);
    }
}

public class EmployeeService
{
    private readonly List<Employee> _employees =
    [
        new Employee(100, "Asha", new DateTime(2021, 6, 1)),
        new Employee(101, "Bharat", new DateTime(2023, 2, 10)),
        new Employee(100, "Asha", new DateTime(2021, 6, 1)),
        new Employee(102, "Chirag", new DateTime(DateTime.Today.Year, 1, 1))
    ];

    public IReadOnlyCollection<Employee> GetEmployees()
    {
        return _employees.Distinct().ToList();
    }

    public IReadOnlyCollection<Employee> GetEmployeesWhoJoinedInPreviousYears()
    {
        return _employees
            .Where(employee => employee.JoinedOn.Year < DateTime.Today.Year)
            .Distinct()
            .ToList();
    }
}
