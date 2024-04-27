using LEVES_University.Models;
using LEVES_University.OtherObjects;

namespace LEVES_University.Interfaces
{
    public interface ISemesterService
    {
        IEnumerable<SemesterInfo> GetAllSemesters();
        SemesterInfo GetSemesterById(int id);
        void AddSemester(SemesterInfo semester);
        void EditSemester(SemesterInfo semester);
        Task<SemesterInfo> GetLastSemester();
        void AddSemesterCourse(int semesterId, int courseId);
        Task<IEnumerable<CourseCatalogue>> GetSemesterCourses();
        Task AddSemesterCourseAsync(SemesterCourseInputModel course);
        Task RemoveSemesterCourseAsync(int id);
        Task<IEnumerable<CourseCatalogue>> GetUnavailableCoursesInSemester();
    }
}
