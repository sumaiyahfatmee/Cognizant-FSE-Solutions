namespace Exercise4_EmployeeManagementSystem
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public double Salary { get; set; }

        public Employee(int employeeId, string name, string position, double salary)
        {
            EmployeeId = employeeId;
            Name = name;
            Position = position;
            Salary = salary;
        }
    }
}