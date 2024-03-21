using Microsoft.EntityFrameworkCore;

namespace Leves_University.Models
{
    public class LevesEntities:DbContext
    {
        public LevesEntities(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Login> Login { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<College> Colleges { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        //public DbSet<Posts> Posts { get; set; }
    }
}
