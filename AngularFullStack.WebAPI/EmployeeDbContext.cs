using AngularFullStack.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularFullStack.WebAPI
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
