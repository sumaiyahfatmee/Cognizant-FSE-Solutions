IF DB_ID('EmployeeManagementDB') IS NULL
BEGIN
    CREATE DATABASE EmployeeManagementDB;
END
GO

USE EmployeeManagementDB;
GO


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
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);


INSERT INTO Departments VALUES
(1,'HR'),
(2,'IT'),
(3,'Finance'),
(4,'Marketing');

INSERT INTO Employees VALUES
(101,'John','Smith',2,60000,'2022-01-15'),
(102,'Alice','Johnson',1,50000,'2021-03-10'),
(103,'Robert','Brown',3,70000,'2020-06-20'),
(104,'Emily','Davis',2,65000,'2023-02-05'),
(105,'Michael','Wilson',4,55000,'2021-11-18');


SELECT * FROM Departments;

SELECT * FROM Employees;

GO
CREATE VIEW vw_EmployeeBasicInfo
AS
SELECT
    E.EmployeeID,
    E.FirstName,
    E.LastName,
    D.DepartmentName
FROM Employees E
JOIN Departments D
ON E.DepartmentID = D.DepartmentID;
GO

SELECT * FROM vw_EmployeeBasicInfo;






GO
CREATE VIEW vw_EmployeeFullName
AS
SELECT
    EmployeeID,
    FirstName + ' ' + LastName AS FullName
FROM Employees;
GO

SELECT * FROM vw_EmployeeFullName;




GO
CREATE VIEW vw_EmployeeAnnualSalary
AS
SELECT
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    Salary * 12 AS AnnualSalary
FROM Employees;
GO

SELECT * FROM vw_EmployeeAnnualSalary;









GO
CREATE VIEW vw_EmployeeAnnualSalary
AS
SELECT
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    Salary * 12 AS AnnualSalary
FROM Employees;
GO

SELECT * FROM vw_EmployeeAnnualSalary;




GO
CREATE VIEW vw_EmployeeReport
AS
SELECT
    E.EmployeeID,
    E.FirstName + ' ' + E.LastName AS FullName,
    D.DepartmentName,
    E.Salary * 12 AS AnnualSalary,
    (E.Salary * 12) * 0.10 AS Bonus
FROM Employees E
JOIN Departments D
ON E.DepartmentID = D.DepartmentID;
GO

SELECT * FROM vw_EmployeeReport;