IF DB_ID('RetailStoreDB') IS NULL
BEGIN
    CREATE DATABASE RetailStoreDB;
END
GO

USE RetailStoreDB;
GO

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    City VARCHAR(50)
);

CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT,
    Quantity INT,
    OrderDate DATE,
    FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Customers VALUES
(1,'Alice','Delhi'),
(2,'Bob','Mumbai'),
(3,'Charlie','Bangalore'),
(4,'David','Hyderabad');

INSERT INTO Products VALUES
(101,'Laptop','Electronics',60000),
(102,'Phone','Electronics',30000),
(103,'Table','Furniture',8000),
(104,'Chair','Furniture',4000);

INSERT INTO Orders VALUES
(1,1,101,1,'2025-01-10'),
(2,2,102,2,'2025-01-12'),
(3,3,103,3,'2025-02-01'),
(4,1,104,4,'2025-02-15'),
(5,4,102,1,'2025-03-05'),
(6,2,101,1,'2025-03-15');

USE RetailStoreDB;
GO

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Orders;

USE RetailStoreDB;
GO

INSERT INTO Customers VALUES
(1,'Alice','Delhi'),
(2,'Bob','Mumbai'),
(3,'Charlie','Bangalore'),
(4,'David','Hyderabad');

INSERT INTO Products VALUES
(101,'Laptop','Electronics',60000),
(102,'Phone','Electronics',30000),
(103,'Table','Furniture',8000),
(104,'Chair','Furniture',4000);

INSERT INTO Orders VALUES
(1,1,101,1,'2025-01-10'),
(2,2,102,2,'2025-01-12'),
(3,3,103,3,'2025-02-01'),
(4,1,104,4,'2025-02-15'),
(5,4,102,1,'2025-03-05'),
(6,2,101,1,'2025-03-15');


SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Orders;

SELECT
    C.CustomerName,
    P.ProductName,
    O.Quantity,
    P.Price,
    (O.Quantity * P.Price) AS TotalAmount,
    ROW_NUMBER() OVER (ORDER BY (O.Quantity * P.Price) DESC) AS RowNum
FROM Orders O
JOIN Customers C
ON O.CustomerID = C.CustomerID
JOIN Products P
ON O.ProductID = P.ProductID;

SELECT
    C.CustomerName,
    P.ProductName,
    (O.Quantity * P.Price) AS TotalAmount,
    RANK() OVER (ORDER BY (O.Quantity * P.Price) DESC) AS RankNo
FROM Orders O
JOIN Customers C
ON O.CustomerID = C.CustomerID
JOIN Products P
ON O.ProductID = P.ProductID;

SELECT
    C.CustomerName,
    P.ProductName,
    (O.Quantity * P.Price) AS TotalAmount,
    DENSE_RANK() OVER (ORDER BY (O.Quantity * P.Price) DESC) AS DenseRankNo
FROM Orders O
JOIN Customers C
ON O.CustomerID = C.CustomerID
JOIN Products P
ON O.ProductID = P.ProductID;


SELECT
    C.CustomerName,
    P.ProductName,
    (O.Quantity * P.Price) AS TotalAmount,
    NTILE(2) OVER (ORDER BY (O.Quantity * P.Price) DESC) AS GroupNo
FROM Orders O
JOIN Customers C
ON O.CustomerID = C.CustomerID
JOIN Products P
ON O.ProductID = P.ProductID;



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
        ) AS RowNum
    FROM Products
) AS RankedProducts
WHERE RowNum <= 3;



SELECT *
FROM
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        RANK() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RankNo
    FROM Products
) AS RankedProducts
WHERE RankNo <= 3;



SELECT *
FROM
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        DENSE_RANK() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS DenseRank
    FROM Products
) AS RankedProducts
WHERE DenseRank <= 3;


ALTER TABLE Customers
ADD Region VARCHAR(50);


UPDATE Customers
SET Region =
CASE CustomerID
    WHEN 1 THEN 'North'
    WHEN 2 THEN 'West'
    WHEN 3 THEN 'South'
    WHEN 4 THEN 'South'
END;


SELECT * FROM Customers;




CREATE TABLE OrderDetails
(
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,

    FOREIGN KEY(OrderID)
        REFERENCES Orders(OrderID),

    FOREIGN KEY(ProductID)
        REFERENCES Products(ProductID)
);



INSERT INTO OrderDetails VALUES
(1,1,101,1),
(2,2,102,2),
(3,3,103,3),
(4,4,104,4),
(5,5,102,1),
(6,6,101,1);



SELECT * FROM OrderDetails;


SELECT
    C.Region,
    P.Category,
    SUM(OD.Quantity) AS TotalQuantity
FROM Customers C
JOIN Orders O
    ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD
    ON O.OrderID = OD.OrderID
JOIN Products P
    ON OD.ProductID = P.ProductID
GROUP BY GROUPING SETS
(
    (C.Region),
    (P.Category),
    (C.Region, P.Category)
);

SELECT
    C.Region,
    P.Category,
    SUM(OD.Quantity) AS TotalQuantity
FROM Customers C
JOIN Orders O
    ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD
    ON O.OrderID = OD.OrderID
JOIN Products P
    ON OD.ProductID = P.ProductID
GROUP BY ROLLUP
(
    C.Region,
    P.Category
);


SELECT
    C.Region,
    P.Category,
    SUM(OD.Quantity) AS TotalQuantity
FROM Customers C
JOIN Orders O
    ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD
    ON O.OrderID = OD.OrderID
JOIN Products P
    ON OD.ProductID = P.ProductID
GROUP BY CUBE
(
    C.Region,
    P.Category
);


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
OPTION (MAXRECURSION 31);


CREATE TABLE StagingProducts
(
    ProductID INT,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);


INSERT INTO StagingProducts VALUES
(101,'Laptop','Electronics',65000),
(102,'Phone','Electronics',32000),
(105,'Headphones','Electronics',5000);


SELECT * FROM StagingProducts;

DROP TABLE StagingProducts;


CREATE TABLE StagingProducts
(
    ProductID INT,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO StagingProducts VALUES
(101,'Laptop','Electronics',65000),
(102,'Phone','Electronics',32000),
(105,'Headphones','Electronics',5000);


SELECT * FROM StagingProducts;


MERGE Products AS Target
USING StagingProducts AS Source
ON Target.ProductID = Source.ProductID

WHEN MATCHED THEN
UPDATE SET
    Target.ProductName = Source.ProductName,
    Target.Category = Source.Category,
    Target.Price = Source.Price

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


SELECT *
FROM Products;




SELECT
    P.ProductName,
    MONTH(O.OrderDate) AS SalesMonth,
    OD.Quantity
FROM Orders O
JOIN OrderDetails OD
    ON O.OrderID = OD.OrderID
JOIN Products P
    ON OD.ProductID = P.ProductID;




    SELECT *
FROM
(
    SELECT
        P.ProductName,
        MONTH(O.OrderDate) AS SalesMonth,
        OD.Quantity
    FROM Orders O
    JOIN OrderDetails OD
        ON O.OrderID = OD.OrderID
    JOIN Products P
        ON OD.ProductID = P.ProductID
) AS SourceData

PIVOT
(
    SUM(Quantity)
    FOR SalesMonth IN
    (
        [1],
        [2],
        [3]
    )
) AS PivotTable;




SELECT
    ProductName,
    SalesMonth,
    Quantity
FROM
(
    SELECT *
    FROM
    (
        SELECT
            P.ProductName,
            MONTH(O.OrderDate) AS SalesMonth,
            OD.Quantity
        FROM Orders O
        JOIN OrderDetails OD
            ON O.OrderID = OD.OrderID
        JOIN Products P
            ON OD.ProductID = P.ProductID
    ) AS SourceData

    PIVOT
    (
        SUM(Quantity)
        FOR SalesMonth IN ([1],[2],[3])
    ) AS PivotTable
) AS P

UNPIVOT
(
    Quantity FOR SalesMonth IN ([1],[2],[3])
) AS UnpivotTable;




INSERT INTO Orders VALUES
(7,1,102,1,'2025-03-20'),
(8,1,103,2,'2025-03-22'),
(9,1,104,1,'2025-03-25');


INSERT INTO OrderDetails VALUES
(7,7,102,1),
(8,8,103,2),
(9,9,104,1);



WITH CustomerOrderCount AS
(
    SELECT
        C.CustomerID,
        C.CustomerName,
        COUNT(O.OrderID) AS TotalOrders
    FROM Customers C
    JOIN Orders O
        ON C.CustomerID = O.CustomerID
    GROUP BY
        C.CustomerID,
        C.CustomerName
)
SELECT *
FROM CustomerOrderCount
WHERE TotalOrders > 3;

