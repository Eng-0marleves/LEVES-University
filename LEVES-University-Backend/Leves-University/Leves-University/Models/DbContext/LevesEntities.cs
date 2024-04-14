using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Leves_University.Models.Dtos;

namespace Leves_University.Models.DbContext
{
    public class LevesEntities : IdentityDbContext<ApplicationUser>
    {
        public LevesEntities(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<FacultyDto> Faculties { get; set; }
        public DbSet<DepartmentDto> Departments { get; set; }
        public DbSet<GPARecord> GPARecords { get; set; }
        public DbSet<Semester> Semesters { get; set; }
    }
}
