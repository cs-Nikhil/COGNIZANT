/*
=========================================================
Exercise 3 - Views
Database : Employee Management System
=========================================================
*/

---------------------------------------------------------
-- Database Schema
---------------------------------------------------------

-- Create Departments Table

CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Create Employees Table

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
(1,'Human Resources'),
(2,'Information Technology'),
(3,'Finance'),
(4,'Marketing');

INSERT INTO Employees
VALUES
(101,'John','Smith',2,50000,'2022-01-15'),
(102,'Alice','Johnson',1,45000,'2021-03-20'),
(103,'Michael','Brown',3,60000,'2020-06-10'),
(104,'Emma','Wilson',4,55000,'2023-02-05');



---------------------------------------------------------
-- Exercise 1 : Create a Simple View
---------------------------------------------------------

-- Goal:
-- Display employee details with department name.

CREATE VIEW vw_EmployeeBasicInfo
AS

SELECT
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName

FROM Employees e

JOIN Departments d
ON e.DepartmentID = d.DepartmentID;



-- View Output

SELECT *
FROM vw_EmployeeBasicInfo;



---------------------------------------------------------
-- Exercise 2 : View with Full Name
---------------------------------------------------------

-- Goal:
-- Create a computed column named FullName.

CREATE VIEW vw_EmployeeFullName
AS

SELECT
    EmployeeID,

    FirstName + ' ' + LastName AS FullName,

    DepartmentID,

    Salary

FROM Employees;



-- View Output

SELECT *
FROM vw_EmployeeFullName;



---------------------------------------------------------
-- Exercise 3 : Annual Salary
---------------------------------------------------------

-- Goal:
-- Calculate Annual Salary.

CREATE VIEW vw_EmployeeAnnualSalary
AS

SELECT
    EmployeeID,

    FirstName,

    LastName,

    Salary,

    Salary * 12 AS AnnualSalary

FROM Employees;



-- View Output

SELECT *
FROM vw_EmployeeAnnualSalary;



---------------------------------------------------------
-- Exercise 4 : Employee Report
---------------------------------------------------------

-- Goal:
-- Display employee report with computed columns.

CREATE VIEW vw_EmployeeReport
AS

SELECT

    e.EmployeeID,

    e.FirstName + ' ' + e.LastName AS FullName,

    d.DepartmentName,

    e.Salary * 12 AS AnnualSalary,

    (e.Salary * 12) * 0.10 AS Bonus

FROM Employees e

JOIN Departments d
ON e.DepartmentID = d.DepartmentID;



-- View Output

SELECT *
FROM vw_EmployeeReport;