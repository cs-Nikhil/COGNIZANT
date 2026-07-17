using NUnit.Framework.Legacy;

namespace CollectionsLib.Tests;

[TestFixture]
public class EmployeeServiceTests
{
    private EmployeeService _employeeService = null!;

    [SetUp]
    public void SetUp()
    {
        _employeeService = new EmployeeService();
    }

    [TearDown]
    public void TearDown()
    {
        _employeeService = null!;
    }

    [Test]
    public void GetEmployees_WhenCalled_ReturnsNonNullCollection()
    {
        var employees = _employeeService.GetEmployees();

        Assert.That(employees, Is.Not.Null);
    }

    [Test]
    public void GetEmployees_WhenCalled_ContainsEmployeeId100_ClassicModel()
    {
        var employeeIds = _employeeService.GetEmployees().Select(employee => employee.EmployeeId).ToArray();

        CollectionAssert.Contains(employeeIds, 100);
    }

    [Test]
    public void GetEmployees_WhenCalled_ReturnsUniqueEmployees_ConstraintModel()
    {
        var employees = _employeeService.GetEmployees();

        Assert.That(employees.Count, Is.EqualTo(employees.Distinct().Count()));
    }

    [Test]
    public void GetEmployees_WhenCalled_DoesNotContainNullItems()
    {
        var employees = _employeeService.GetEmployees();

        CollectionAssert.AllItemsAreNotNull(employees.ToList());
    }

    [Test]
    public void GetEmployeesWhoJoinedInPreviousYears_WhenCalled_ReturnsOnlyOlderEmployees()
    {
        var employees = _employeeService.GetEmployeesWhoJoinedInPreviousYears();

        Assert.That(employees, Is.All.Matches<Employee>(employee => employee.JoinedOn.Year < DateTime.Today.Year));
    }
}
