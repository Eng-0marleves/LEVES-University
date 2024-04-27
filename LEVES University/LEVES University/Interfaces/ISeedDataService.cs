using LEVES_University.Models;

namespace LEVES_University.Interfaces
{
    public interface ISeedDataService
    {
        Task SeedRolesAsync();
        Task SeedUsersAsync();
        Task SeedCollegesAsync();
        Task SeedAreasOfStudyAsync();
        Task SeedCoursesAsync();
        Task<IEnumerable<CourseCatalogue>> GetCoursesAsync();
        Task SeedStudentsAsync();
    }
}
