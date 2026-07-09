USE RetailStoreDB;
GO

SELECT * FROM Customers;

SELECT * FROM Products;

SELECT * FROM Orders;


CREATE NONCLUSTERED INDEX IX_Customers_CustomerName
ON Customers(CustomerName);

EXEC sp_helpindex 'Customers';

CREATE NONCLUSTERED INDEX IX_Products_Category_Price
ON Products(Category, Price);


EXEC sp_helpindex 'Products';



SELECT *
FROM Products
WHERE Category='Electronics'
ORDER BY Price;


SELECT
    OBJECT_NAME(object_id) AS TableName,
    name AS IndexName,
    type_desc
FROM sys.indexes
WHERE OBJECT_NAME(object_id) IN
(
    'Customers',
    'Products',
    'Orders'
);