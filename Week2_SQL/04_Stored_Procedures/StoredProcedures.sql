USE EmployeeManagementDB;
GO

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees
    (
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @DepartmentID,
        @Salary,
        @JoinDate
    );
END;
GO



EXEC sp_InsertEmployee
    'Chris',
    'Martin',
    3,
    7500,
    '2024-01-15';


SELECT * FROM Employees;



EXEC sp_InsertEmployee
    'Chris',
    'Martin',
    3,
    7500,
    '2024-01-15';


    DROP PROCEDURE sp_InsertEmployee;
GO


CREATE PROCEDURE sp_InsertEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees
    (
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    )
    VALUES
    (
        @EmployeeID,
        @FirstName,
        @LastName,
        @DepartmentID,
        @Salary,
        @JoinDate
    );
END;
GO





EXEC sp_InsertEmployee
    106,
    'Chris',
    'Martin',
    3,
    7500,
    '2024-01-15';
GO



SELECT * FROM Employees;





GO
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT
        DepartmentID,
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID
    GROUP BY DepartmentID;
END;
GO



EXEC sp_GetEmployeeCountByDepartment 3;