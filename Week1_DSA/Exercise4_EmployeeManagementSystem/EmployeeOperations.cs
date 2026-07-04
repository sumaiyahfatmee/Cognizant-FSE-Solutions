using System;

namespace Exercise4_EmployeeManagementSystem
{
    public class EmployeeOperations
    {
        // Traverse Employees
        public static void Traverse(Employee[] employees)
        {
            Console.WriteLine("\nEmployee Records:");

            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary}");
                }
            }
        }

        // Search Employee
        public static Employee Search(Employee[] employees, int employeeId)
        {
            foreach (Employee employee in employees)
            {
                if (employee != null && employee.EmployeeId == employeeId)
                {
                    return employee;
                }
            }

            return null;
        }

        // Delete Employee
        public static void Delete(Employee[] employees, int employeeId)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].EmployeeId == employeeId)
                {
                    employees[i] = null;
                    Console.WriteLine("Employee deleted successfully.");
                    return;
                }
            }

            Console.WriteLine("Employee not found.");
        }
    }
}