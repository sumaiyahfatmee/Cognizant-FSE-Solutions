using Microsoft.AspNetCore.Authorization;
using FirstWebAPIControllers.Filters;
using Microsoft.AspNetCore.Mvc;
using FirstWebAPIControllers.Models;

namespace FirstWebAPIControllers.Controllers
{
  [ApiController]
[Route("[controller]")]
//[CustomAuthFilter]
[CustomExceptionFilter]
[Authorize]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
{
    new Employee
    {
        Id = 1,
        Name = "John",
        Salary = 50000,
        Permanent = true,
        DateOfBirth = new DateTime(1998, 5, 10),

        Department = new Department
        {
            Id = 101,
            Name = "IT"
        },

        Skills = new List<Skill>
        {
            new Skill
            {
                Id = 1,
                Name = "C#"
            },
            new Skill
            {
                Id = 2,
                Name = "ASP.NET Core"
            }
        }
    }
};
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            return Ok(employee);
        }
        [HttpPut("{id}")]
public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmployee)


{  if (id <= 0)
    {
        return BadRequest("Invalid employee id");
    }


    var employee = employees.FirstOrDefault(e => e.Id == id);

    if (employee == null)
    {
        return BadRequest("Employee not found");
    }

    employee.Name = updatedEmployee.Name;
    employee.Salary = updatedEmployee.Salary;
    employee.Permanent = updatedEmployee.Permanent;
    employee.Department = updatedEmployee.Department;
    employee.Skills = updatedEmployee.Skills;
    employee.DateOfBirth = updatedEmployee.DateOfBirth;

    return Ok(employee);
}
[HttpDelete("{id}")]
public ActionResult Delete(int id)
{
    var employee = employees.FirstOrDefault(e => e.Id == id);

    if (employee == null)
    {
        return BadRequest("Employee not found");
    }

    employees.Remove(employee);

    return Ok("Employee deleted successfully");
}


    }
}