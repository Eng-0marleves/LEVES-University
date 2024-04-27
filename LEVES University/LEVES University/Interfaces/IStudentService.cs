using LEVES_University.Models;
using LEVES_University.OtherObjects;

namespace LEVES_University.Interfaces
{
    public interface IStudentService
    {
        //Task<IEnumerable<CourseAreaOfStudy>> GetStudentAreaCourses(string id);
        Task<Users> GetStudentByIdAsync(string id);
        Task<List<AllStudentsModelDto>> GetAllStudentsAsync();
        Task AddStudentAsync(StudentInputDto student);
        Task<List<AreaOfStudy>> GetAreasOfStudyAsync();
    }
}
