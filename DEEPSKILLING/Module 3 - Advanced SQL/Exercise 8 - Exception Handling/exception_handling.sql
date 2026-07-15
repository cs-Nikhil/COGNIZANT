/*
=========================================================
Exercise 8 - Exception Handling
Database : Employee Management System
=========================================================
*/

---------------------------------------------------------
-- Database Schema
---------------------------------------------------------

CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Salary DECIMAL(10,2),
    DepartmentID INT,

    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);

CREATE TABLE AuditLog
(
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    Action VARCHAR(100),
    ErrorMessage VARCHAR(4000),
    ActionDate DATETIME DEFAULT GETDATE()
);

---------------------------------------------------------
-- Sample Data
---------------------------------------------------------

INSERT INTO Departments
VALUES
(1,'HR'),
(2,'Finance'),
(3,'IT');

INSERT INTO Employees
VALUES
(1,'John','Doe','john@gmail.com',5000,1),
(2,'Jane','Smith','jane@gmail.com',6000,2),
(3,'Bob','Johnson','bob@gmail.com',7000,3);



---------------------------------------------------------
-- Exercise 1 : TRY...CATCH for Error Logging
---------------------------------------------------------

-- Goal:
-- Insert a new employee and log errors.

CREATE PROCEDURE AddEmployee

    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT

AS
BEGIN

    BEGIN TRY

        INSERT INTO Employees
        (
            EmployeeID,
            FirstName,
            LastName,
            Email,
            Salary,
            DepartmentID
        )

        VALUES
        (
            @EmployeeID,
            @FirstName,
            @LastName,
            @Email,
            @Salary,
            @DepartmentID
        );

        PRINT 'Employee Added Successfully';

    END TRY

    BEGIN CATCH

        INSERT INTO AuditLog
        (
            Action,
            ErrorMessage
        )

        VALUES
        (
            'Add Employee',
            ERROR_MESSAGE()
        );

    END CATCH

END;

-- Test

EXEC AddEmployee
4,'Emily','Davis','john@gmail.com',5500,2;



---------------------------------------------------------
-- Exercise 2 : THROW
---------------------------------------------------------

-- Goal:
-- Log the error and re-throw it.

ALTER PROCEDURE AddEmployee

    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT

AS
BEGIN

    BEGIN TRY

        INSERT INTO Employees
        VALUES
        (
            @EmployeeID,
            @FirstName,
            @LastName,
            @Email,
            @Salary,
            @DepartmentID
        );

    END TRY

    BEGIN CATCH

        INSERT INTO AuditLog
        (
            Action,
            ErrorMessage
        )

        VALUES
        (
            'Add Employee',
            ERROR_MESSAGE()
        );

        THROW;

    END CATCH

END;



---------------------------------------------------------
-- Exercise 3 : RAISERROR
---------------------------------------------------------

-- Goal:
-- Salary must be greater than zero.

ALTER PROCEDURE AddEmployee

    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT

AS
BEGIN

    IF @Salary <= 0

    BEGIN

        RAISERROR
        (
            'Salary must be greater than zero.',
            16,
            1
        );

        RETURN;

    END

    INSERT INTO Employees
    VALUES
    (
        @EmployeeID,
        @FirstName,
        @LastName,
        @Email,
        @Salary,
        @DepartmentID
    );

END;



---------------------------------------------------------
-- Exercise 4 : Nested TRY...CATCH
---------------------------------------------------------

-- Goal:
-- Transfer an employee to another department.

CREATE PROCEDURE TransferEmployee

    @EmployeeID INT,
    @DepartmentID INT

AS
BEGIN

    BEGIN TRY

        BEGIN TRY

            IF NOT EXISTS
            (
                SELECT *
                FROM Departments
                WHERE DepartmentID=@DepartmentID
            )

            BEGIN

                RAISERROR
                (
                    'Department does not exist.',
                    16,
                    1
                );

            END

            UPDATE Employees

            SET DepartmentID=@DepartmentID

            WHERE EmployeeID=@EmployeeID;

        END TRY

        BEGIN CATCH

            INSERT INTO AuditLog
            (
                Action,
                ErrorMessage
            )

            VALUES
            (
                'Transfer Employee',
                ERROR_MESSAGE()
            );

            THROW;

        END CATCH

    END TRY

    BEGIN CATCH

        PRINT ERROR_MESSAGE();

    END CATCH

END;



---------------------------------------------------------
-- Exercise 5 : Transaction with TRY...CATCH
---------------------------------------------------------

-- Goal:
-- Insert multiple employees using a transaction.

CREATE PROCEDURE BatchInsertEmployees

AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO Employees
        VALUES
        (
            5,
            'Rahul',
            'Sharma',
            'rahul@gmail.com',
            5500,
            1
        );

        INSERT INTO Employees
        VALUES
        (
            6,
            'Priya',
            'Singh',
            'john@gmail.com',
            6000,
            2
        );

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        INSERT INTO AuditLog
        (
            Action,
            ErrorMessage
        )

        VALUES
        (
            'Batch Insert',
            ERROR_MESSAGE()
        );

    END CATCH

END;

-- Execute

EXEC BatchInsertEmployees;



---------------------------------------------------------
-- Exercise 6 : Dynamic RAISERROR
---------------------------------------------------------

-- Goal:
-- Raise different messages based on salary.

ALTER PROCEDURE AddEmployee

    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT

AS
BEGIN

    IF @Salary < 0

    BEGIN

        RAISERROR
        (
            'Salary cannot be negative.',
            16,
            1
        );

        RETURN;

    END

    IF @Salary < 1000

    BEGIN

        RAISERROR
        (
            'Warning: Salary is very low.',
            10,
            1
        );

    END

    INSERT INTO Employees
    VALUES
    (
        @EmployeeID,
        @FirstName,
        @LastName,
        @Email,
        @Salary,
        @DepartmentID
    );

END;

-- Test

EXEC AddEmployee
7,
'Amit',
'Kumar',
'amit@gmail.com',
800,
1;



---------------------------------------------------------
-- Verify Audit Log
---------------------------------------------------------

SELECT *
FROM AuditLog;