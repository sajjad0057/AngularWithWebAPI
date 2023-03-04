using Crud_back.Data;
using Crud_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly CrudDbContext _dbContext;

        public EmployeesController(CrudDbContext dbContext)
        {
            _dbContext= dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _dbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employeeRequest)
        {
            try
            {
                employeeRequest.Id = Guid.NewGuid();

                await _dbContext.Employees.AddAsync(employeeRequest);
                await _dbContext.SaveChangesAsync();

                return Ok(employeeRequest);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute]Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employee is not null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,Employee updateEmployeRequest)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if(employee is not null)
            { 
                employee.Name = updateEmployeRequest.Name;
                employee.Email = updateEmployeRequest.Email;
                employee.Salary = updateEmployeRequest.Salary;
                employee.Phone = updateEmployeRequest.Phone;
                employee.Department = updateEmployeRequest.Department;

                await _dbContext.SaveChangesAsync();

                return Ok(employee);

            } 
            else
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee is not null)
            {
                _dbContext.Employees.Remove(employee);

                await _dbContext.SaveChangesAsync();

                return Ok(employee);

            }
            else
            {
                return NotFound();
            }
        }
    }
}
