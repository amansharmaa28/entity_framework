using entity_framework.Models.Cascade;
using Microsoft.EntityFrameworkCore;

namespace entity_framework.Models
{
    public class EmpDbContext :DbContext
    {
        public EmpDbContext(DbContextOptions options) : base(options)
        { 
        
        }

        public DbSet<Emp> emps { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> states { get; set; }

        public DbSet<City> City { get; set; }
    }
}
