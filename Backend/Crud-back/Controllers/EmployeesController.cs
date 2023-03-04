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
    }
}
