using DemoMvc14.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc14.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

      

    }
}
