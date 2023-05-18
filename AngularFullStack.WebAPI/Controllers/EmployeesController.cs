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

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute]Guid id)
        {
            try
            {
                var result = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployeeByIdAsync([FromRoute] Guid id, Employee employeeRequest)
        {
            try {
                var result = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                {
                    return NotFound();
                }
                    result.Name = employeeRequest.Name;
                    result.Email = employeeRequest.Email;
                    result.Phone = employeeRequest.Phone;
                    result.Address = employeeRequest.Address;
                    result.Salary = employeeRequest.Salary;
                    result.Department = employeeRequest.Department;

                //saving the updated changes to database
                await _employeeDbContext.SaveChangesAsync();
                return Ok(result);
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
