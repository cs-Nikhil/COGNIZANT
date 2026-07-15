/*
=========================================================
Exercise 2 - SQL Indexing
Database : Online Retail Store
=========================================================
*/

---------------------------------------------------------
-- Exercise 1 : Non-Clustered Index
---------------------------------------------------------

-- Goal:
-- Create a non-clustered index on the ProductName column
-- and compare query execution before and after index creation.

-- Step 1 : Query before creating the index

SELECT *
FROM Products
WHERE ProductName = 'Laptop';

-- Step 2 : Create a non-clustered index

CREATE NONCLUSTERED INDEX IX_ProductName
ON Products(ProductName);

-- Step 3 : Query after creating the index

SELECT *
FROM Products
WHERE ProductName = 'Laptop';



---------------------------------------------------------
-- Exercise 2 : Clustered Index
---------------------------------------------------------

-- Goal:
-- Create a clustered index on the OrderDate column
-- and compare query execution before and after index creation.

-- Step 1 : Query before creating the index

SELECT *
FROM Orders
WHERE OrderDate = '2023-01-15';

-- Step 2 : Create a clustered index

-- Note:
-- Orders table already has a clustered index because
-- OrderID is the Primary Key.
-- The following statement is for learning purposes.

CREATE CLUSTERED INDEX IX_OrderDate
ON Orders(OrderDate);

-- Step 3 : Query after creating the index

SELECT *
FROM Orders
WHERE OrderDate = '2023-01-15';



---------------------------------------------------------
-- Exercise 3 : Composite Index
---------------------------------------------------------

-- Goal:
-- Create a composite index on CustomerID and OrderDate
-- to improve search performance.

-- Step 1 : Query before creating the index

SELECT *
FROM Orders
WHERE CustomerID = 1
AND OrderDate = '2023-01-15';

-- Step 2 : Create a composite index

CREATE NONCLUSTERED INDEX IX_Customer_OrderDate
ON Orders(CustomerID, OrderDate);

-- Step 3 : Query after creating the index

SELECT *
FROM Orders
WHERE CustomerID = 1
AND OrderDate = '2023-01-15';