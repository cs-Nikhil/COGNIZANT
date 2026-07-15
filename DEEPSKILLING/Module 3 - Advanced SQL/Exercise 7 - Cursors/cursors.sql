/*
=========================================================
Exercise 7 - Cursors
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
(3,'Bob','Johnson',3,5500.00,'2021-07-30');



---------------------------------------------------------
-- Exercise 1 : Create a Cursor
---------------------------------------------------------

-- Goal:
-- Iterate through all employee records and display details.

DECLARE
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE;

DECLARE EmployeeCursor CURSOR

FOR

SELECT
    EmployeeID,
    FirstName,
    LastName,
    DepartmentID,
    Salary,
    JoinDate

FROM Employees;

OPEN EmployeeCursor;

FETCH NEXT
FROM EmployeeCursor
INTO
@EmployeeID,
@FirstName,
@LastName,
@DepartmentID,
@Salary,
@JoinDate;

WHILE @@FETCH_STATUS = 0

BEGIN

    PRINT 'Employee ID : ' + CAST(@EmployeeID AS VARCHAR);

    PRINT 'Employee Name : ' + @FirstName + ' ' + @LastName;

    PRINT 'Department ID : ' + CAST(@DepartmentID AS VARCHAR);

    PRINT 'Salary : ' + CAST(@Salary AS VARCHAR);

    PRINT 'Join Date : ' + CONVERT(VARCHAR,@JoinDate,23);

    PRINT '------------------------------';

    FETCH NEXT
    FROM EmployeeCursor
    INTO
    @EmployeeID,
    @FirstName,
    @LastName,
    @DepartmentID,
    @Salary,
    @JoinDate;

END;

CLOSE EmployeeCursor;

DEALLOCATE EmployeeCursor;



---------------------------------------------------------
-- Exercise 2 : Static Cursor
---------------------------------------------------------

-- Goal:
-- Create a Static Cursor.

DECLARE StaticCursor CURSOR STATIC

FOR

SELECT *
FROM Employees;

OPEN StaticCursor;

PRINT 'Static Cursor Created Successfully';

CLOSE StaticCursor;

DEALLOCATE StaticCursor;



---------------------------------------------------------
-- Exercise 3 : Dynamic Cursor
---------------------------------------------------------

-- Goal:
-- Create a Dynamic Cursor.

DECLARE DynamicCursor CURSOR DYNAMIC

FOR

SELECT *
FROM Employees;

OPEN DynamicCursor;

PRINT 'Dynamic Cursor Created Successfully';

CLOSE DynamicCursor;

DEALLOCATE DynamicCursor;



---------------------------------------------------------
-- Exercise 4 : Forward Only Cursor
---------------------------------------------------------

-- Goal:
-- Create a Forward Only Cursor.

DECLARE ForwardCursor CURSOR FORWARD_ONLY

FOR

SELECT *
FROM Employees;

OPEN ForwardCursor;

PRINT 'Forward Only Cursor Created Successfully';

CLOSE ForwardCursor;

DEALLOCATE ForwardCursor;



---------------------------------------------------------
-- Exercise 5 : Keyset Cursor
---------------------------------------------------------

-- Goal:
-- Create a Keyset Cursor.

DECLARE KeysetCursor CURSOR KEYSET

FOR

SELECT *
FROM Employees;

OPEN KeysetCursor;

PRINT 'Keyset Cursor Created Successfully';

CLOSE KeysetCursor;

DEALLOCATE KeysetCursor;



---------------------------------------------------------
-- Cursor Types
---------------------------------------------------------

-- Static Cursor
-- Creates a snapshot of the data.
-- Changes made after opening are not visible.

-- Dynamic Cursor
-- Displays all changes made while the cursor is open.

-- Forward Only Cursor
-- Moves only in the forward direction.
-- Fastest cursor type.

-- Keyset Cursor
-- Stores only key values.
-- Updates are visible but newly inserted rows are not.