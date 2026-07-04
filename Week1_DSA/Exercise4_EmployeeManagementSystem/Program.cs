
using System;

namespace Exercise4_EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[5];

            // Add Employees
            employees[0] = new Employee(101, "Rahul", "Manager", 75000);
            employees[1] = new Employee(102, "Priya", "Developer", 60000);
            employees[2] = new Employee(103, "Aman", "Tester", 50000);
            employees[3] = new Employee(104, "Sneha", "HR", 55000);
            employees[4] = new Employee(105, "Rohit", "Designer", 58000);

            Console.WriteLine("===== Employee List =====");
            EmployeeOperations.Traverse(employees);

            Console.WriteLine("\nSearching for Employee ID 103...");
            Employee result = EmployeeOperations.Search(employees, 103);

            if (result != null)
            {
                Console.WriteLine($"Found: {result.Name}, {result.Position}, Salary: {result.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            Console.WriteLine("\nDeleting Employee ID 103...");
            EmployeeOperations.Delete(employees, 103);

            Console.WriteLine("\n===== Employee List After Deletion =====");
            EmployeeOperations.Traverse(employees);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}