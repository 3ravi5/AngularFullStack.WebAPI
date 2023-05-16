using AngularFullStack.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularFullStack.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeesController : Controller
    {

        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeesController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployess()
        {
            var employees = await _employeeDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employeeRequest)
        {
            try
            {
                employeeRequest.Id = Guid.NewGuid();
                var employees = await _employeeDbContext.Employees.AddAsync(employeeRequest);
                await _employeeDbContext.SaveChangesAsync();
                return Ok(employeeRequest);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
