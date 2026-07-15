/*
=========================================================
Exercise 5 - Functions
Database : Employee Management System
=========================================================
*/

---------------------------------------------------------
-- Database Schema
---------------------------------------------------------

CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,

    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);

---------------------------------------------------------
-- Sample Data
---------------------------------------------------------

INSERT INTO Departments
VALUES
(1,'HR'),
(2,'IT'),
(3,'Finance');

INSERT INTO Employees
VALUES
(1,'John','Doe',1,5000.00,'2020-01-15'),
(2,'Jane','Smith',2,6000.00,'2019-03-22'),
(3,'Bob','Johnson',3,5500.00,'2021-07-01');



---------------------------------------------------------
-- Exercise 1 : Create a Scalar Function
---------------------------------------------------------

-- Goal:
-- Calculate the annual salary of an employee.

CREATE FUNCTION fn_CalculateAnnualSalary
(
    @Salary DECIMAL(10,2)
)

RETURNS DECIMAL(10,2)

AS
BEGIN

    RETURN @Salary * 12;

END;

-- Test

SELECT
    EmployeeID,
    FirstName,
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;



---------------------------------------------------------
-- Exercise 2 : Create a Table-Valued Function
---------------------------------------------------------

-- Goal:
-- Return employees belonging to a specific department.

CREATE FUNCTION fn_GetEmployeesByDepartment
(
    @DepartmentID INT
)

RETURNS TABLE

AS

RETURN
(
    SELECT
        EmployeeID,
        FirstName,
        LastName,
        Salary,
        JoinDate

    FROM Employees

    WHERE DepartmentID = @DepartmentID
);

-- Test

SELECT *
FROM dbo.fn_GetEmployeesByDepartment(2);



---------------------------------------------------------
-- Exercise 3 : Create a User Defined Function
---------------------------------------------------------

-- Goal:
-- Calculate 10% bonus.

CREATE FUNCTION fn_CalculateBonus
(
    @Salary DECIMAL(10,2)
)

RETURNS DECIMAL(10,2)

AS
BEGIN

    RETURN @Salary * 0.10;

END;

-- Test

SELECT
    EmployeeID,
    FirstName,
    Salary,
    dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;



---------------------------------------------------------
-- Exercise 4 : Modify the Bonus Function
---------------------------------------------------------

-- Goal:
-- Change bonus calculation from 10% to 15%.

ALTER FUNCTION fn_CalculateBonus
(
    @Salary DECIMAL(10,2)
)

RETURNS DECIMAL(10,2)

AS
BEGIN

    RETURN @Salary * 0.15;

END;

-- Test

SELECT
    EmployeeID,
    FirstName,
    Salary,
    dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;



---------------------------------------------------------
-- Exercise 5 : Delete User Defined Function
---------------------------------------------------------

DROP FUNCTION fn_CalculateBonus;

-- Verify

SELECT *
FROM sys.objects
WHERE type = 'FN'
AND name = 'fn_CalculateBonus';



---------------------------------------------------------
-- Exercise 6 : Execute Scalar Function
---------------------------------------------------------

SELECT
    EmployeeID,
    FirstName,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;



---------------------------------------------------------
-- Exercise 7 : Return Data from Scalar Function
---------------------------------------------------------

SELECT
    EmployeeID,
    FirstName,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary

FROM Employees

WHERE EmployeeID = 1;



---------------------------------------------------------
-- Exercise 8 : Execute Table-Valued Function
---------------------------------------------------------

SELECT *
FROM dbo.fn_GetEmployeesByDepartment(3);



---------------------------------------------------------
-- Exercise 9 : Nested User Defined Function
---------------------------------------------------------

CREATE FUNCTION fn_CalculateTotalCompensation
(
    @Salary DECIMAL(10,2)
)

RETURNS DECIMAL(10,2)

AS
BEGIN

    RETURN
        dbo.fn_CalculateAnnualSalary(@Salary)
        +
        dbo.fn_CalculateBonus(@Salary);

END;

-- Test

SELECT
    EmployeeID,
    FirstName,
    Salary,
    dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation

FROM Employees;



---------------------------------------------------------
-- Exercise 10 : Modify Nested Function
---------------------------------------------------------

ALTER FUNCTION fn_CalculateTotalCompensation
(
    @Salary DECIMAL(10,2)
)

RETURNS DECIMAL(10,2)

AS
BEGIN

    RETURN
        dbo.fn_CalculateAnnualSalary(@Salary)
        +
        dbo.fn_CalculateBonus(@Salary);

END;

-- Test

SELECT
    EmployeeID,
    FirstName,
    Salary,
    dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation

FROM Employees;