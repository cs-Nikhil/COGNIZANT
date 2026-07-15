-- Exercise 1 - Advanced SQL
-- Add your SQL solutions here.
/*
=========================================================
Exercise 1 - Advanced SQL
Database : Online Retail Store
=========================================================
*/

---------------------------------------------------------
-- Exercise 1 : Ranking and Window Functions
---------------------------------------------------------

-- Goal:
-- Use ROW_NUMBER(), RANK(), DENSE_RANK(), OVER() and PARTITION BY.

-- Scenario:
-- Find the top 3 most expensive products in each category.

-- Steps:
-- 1. Assign a unique rank using ROW_NUMBER().
-- 2. Compare RANK() and DENSE_RANK().
-- 3. Partition by Category and order by Price.

SELECT *
FROM
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,

        ROW_NUMBER() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNumber,

        RANK() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RankNumber,

        DENSE_RANK() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS DenseRank

    FROM Products

) AS RankedProducts

WHERE RowNumber <= 3;



---------------------------------------------------------
-- Exercise 2 : GROUPING SETS, ROLLUP and CUBE
---------------------------------------------------------

-- Goal:
-- Analyze sales data across multiple dimensions.

-- Scenario:
-- Show total quantity sold by Region and Category.

---------------------------------------------------------
-- GROUPING SETS
---------------------------------------------------------

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity

FROM Orders o

JOIN Customers c
ON o.CustomerID = c.CustomerID

JOIN OrderDetails od
ON o.OrderID = od.OrderID

JOIN Products p
ON od.ProductID = p.ProductID

GROUP BY GROUPING SETS
(
    (c.Region),
    (p.Category),
    (c.Region, p.Category)
);



---------------------------------------------------------
-- ROLLUP
---------------------------------------------------------

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity

FROM Orders o

JOIN Customers c
ON o.CustomerID = c.CustomerID

JOIN OrderDetails od
ON o.OrderID = od.OrderID

JOIN Products p
ON od.ProductID = p.ProductID

GROUP BY ROLLUP
(
    c.Region,
    p.Category
);



---------------------------------------------------------
-- CUBE
---------------------------------------------------------

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity

FROM Orders o

JOIN Customers c
ON o.CustomerID = c.CustomerID

JOIN OrderDetails od
ON o.OrderID = od.OrderID

JOIN Products p
ON od.ProductID = p.ProductID

GROUP BY CUBE
(
    c.Region,
    p.Category
);



---------------------------------------------------------
-- Exercise 3 : Recursive CTE and MERGE
---------------------------------------------------------

-- Goal:
-- Use Recursive CTE and MERGE.

-- Scenario:
-- Generate a calendar table and update Products
-- from a staging table.

---------------------------------------------------------
-- Recursive CTE
---------------------------------------------------------

WITH Calendar AS
(
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate

    UNION ALL

    SELECT DATEADD(DAY,1,CalendarDate)

    FROM Calendar

    WHERE CalendarDate < '2025-01-31'
)

SELECT *
FROM Calendar

OPTION (MAXRECURSION 100);



---------------------------------------------------------
-- Create Staging Table
---------------------------------------------------------

CREATE TABLE StagingProducts
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO StagingProducts
VALUES
(1,'Laptop','Electronics',1250.00),
(5,'Keyboard','Accessories',80.00);



---------------------------------------------------------
-- MERGE
---------------------------------------------------------

MERGE Products AS Target

USING StagingProducts AS Source

ON Target.ProductID = Source.ProductID

WHEN MATCHED THEN

UPDATE
SET Target.Price = Source.Price

WHEN NOT MATCHED THEN

INSERT
(
    ProductID,
    ProductName,
    Category,
    Price
)

VALUES
(
    Source.ProductID,
    Source.ProductName,
    Source.Category,
    Source.Price
);



---------------------------------------------------------
-- Exercise 4 : PIVOT and UNPIVOT
---------------------------------------------------------

-- Goal:
-- Convert rows into columns and columns into rows.

---------------------------------------------------------
-- PIVOT
---------------------------------------------------------

SELECT *

FROM
(
    SELECT
        p.ProductName,
        MONTH(o.OrderDate) AS SalesMonth,
        od.Quantity

    FROM Orders o

    JOIN OrderDetails od
    ON o.OrderID = od.OrderID

    JOIN Products p
    ON od.ProductID = p.ProductID

) AS SalesData

PIVOT
(
    SUM(Quantity)

    FOR SalesMonth IN
    (
        [1],[2],[3],[4],[5],[6],
        [7],[8],[9],[10],[11],[12]
    )

) AS MonthlySales;



---------------------------------------------------------
-- UNPIVOT
---------------------------------------------------------

SELECT
    ProductName,
    SalesMonth,
    Quantity

FROM MonthlySales

UNPIVOT
(
    Quantity

    FOR SalesMonth IN
    (
        [1],[2],[3],[4],[5],[6],
        [7],[8],[9],[10],[11],[12]
    )

) AS SalesRows;



---------------------------------------------------------
-- Exercise 5 : Common Table Expression (CTE)
---------------------------------------------------------

-- Goal:
-- Find customers who placed more than 3 orders.

WITH CustomerOrderCounts AS
(
    SELECT
        o.CustomerID,
        COUNT(o.OrderID) AS OrderCount

    FROM Orders o

    GROUP BY o.CustomerID
)

SELECT
    c.CustomerID,
    c.Name,
    coc.OrderCount

FROM CustomerOrderCounts coc

JOIN Customers c
ON c.CustomerID = coc.CustomerID

WHERE coc.OrderCount > 3;