using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LEVES_University.Models;
using Microsoft.Extensions.Configuration;

namespace LEVES_University.DBContext
{
    public class LevesEntities : DbContext
    {
        public LevesEntities(DbContextOptions<LevesEntities> options, IConfiguration configuration)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserProfilePicture> UsersProfilePicture { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
     
        public DbSet<JopInformation> JopInformation { get; set; }

        public DbSet<StudentInfo > StudentInfo { get; set; }

        public DbSet<AreaOfStudy> AreasOfStudy { get; set; }

        public DbSet<College> Colleges { get; set; }

        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }

        public DbSet<StudentGradingStatus> StudentGradingStatuses { get; set; }
    
        public DbSet<Grades> Grades { get; set; }

        public DbSet<CourseSchedule> CoursesSchedules { get; set; }

        public DbSet<CourseCatalogue> CoursesCatalogues { get; set; }

        public DbSet<CourseAreaOfStudy> CourseAreaOfStudy { get; set; }


        public DbSet<SemesterInfo> SemestersInfo { get; set; }

        public DbSet<ClassRoom> Classrooms { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Prerequisites> Prerequisites { get; set; }

        public DbSet<CourseDailySchedule> courseDailySchedules { get; set; }
        public DbSet<SemesterCourse> SemesterCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prerequisites>()
                .HasOne(p => p.ParentCourse)
                .WithMany()
                .HasForeignKey(p => p.ParentCourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prerequisites>()
                .HasOne(p => p.ChildCourse)
                .WithMany()
                .HasForeignKey(p => p.ChildCourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CourseEnrollment>()
                .HasOne(ce => ce.CourseSchedule)
                .WithMany()
                .HasForeignKey(ce => ce.CourseScheduleId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public async Task SeedUsersAsync(IEnumerable<Users> users)
        {
            await Users.AddRangeAsync(users);
            await SaveChangesAsync();
        }
    }   
}
