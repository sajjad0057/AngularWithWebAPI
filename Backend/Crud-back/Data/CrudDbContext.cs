using Crud_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_back.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
