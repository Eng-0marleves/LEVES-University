using LEVES_University.DBContext;
using LEVES_University.Interfaces;
using LEVES_University.Models;
using LEVES_University.OtherObjects;
using Microsoft.EntityFrameworkCore;

namespace LEVES_University.Services
{
    public class StudentService: IStudentService
    {
        private readonly LevesEntities _dbContext;

        public StudentService(LevesEntities dbContext)
        {
            _dbContext = dbContext;
        }


        //public async Task<IEnumerable<CourseAreaOfStudy>> GetStudentAreaCourses(string id)
        //{
        //    //var student = await _dbContext.StudentInfo.FindAsync(id);

        //    //var areaId = student.AreaOfStudyId;

        //    //var courses = await _dbContext.CourseAreaOfStudy
        //    //    .Where(course => course.AreaOfStudyId == areaId)
        //    //    .ToListAsync();

        //    //return courses;

        //    throw new Exception();
        //}



        public async Task<Users?> GetStudentByIdAsync(string id)
        {
            try
            {
                return await _dbContext.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<AllStudentsModelDto>> GetAllStudentsAsync()
        {
            try
            {
                var allStudents = await (
                    from user in _dbContext.Users
                    join studentInfo in _dbContext.StudentInfo on user.Id equals studentInfo.StudentId
                    where user.RoleId == 1
                    select new AllStudentsModelDto
                    {
                        StudentId = user.Id,
                        Grade = studentInfo.Grade,
                        GPA = studentInfo.GPA,
                        AreaOfStudy = _dbContext.AreasOfStudy.FirstOrDefault(a => a.Id == studentInfo.AreaOfStudyId).StudyTitle,
                        NTID = user.NTID,
                        Name = $"{user.FirstName} {user.LastName}",
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber
                    }
                ).ToListAsync();

                return allStudents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task AddStudentAsync(StudentInputDto student)
        {
            try
            {
                // Create a new user
                var user = new Users() { FirstName = student.FirstName, LastName = student.LastName, Email = student.Email, PhoneNumber = student.PhoneNumber, NTID = student.NTID, DateOfBirth = student.DateOfBirth, RoleId = 1};

                var address = new Address
                {
                    City = student.City,
                    Street1 = student.Street1,
                    Street2 = student.Street2,
                    Zip = student.Zip
                };

                user.Address = address;

                var studentInfo = new StudentInfo
                {
                    User = user,
                    AreaOfStudyId = GetAreaOfStudyId(student.AreaOfStudy)
                };

                // Save to database
                await _dbContext.Users.AddAsync(user);
                await _dbContext.Addresses.AddAsync(address);
                await _dbContext.StudentInfo.AddAsync(studentInfo);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding student: " + ex.Message);
            }
        }

        private int GetAreaOfStudyId(string areaOfStudyTitle)
        {
            var areaOfStudy = _dbContext.AreasOfStudy.FirstOrDefault(a => a.StudyTitle == areaOfStudyTitle);
            if (areaOfStudy == null)
            {
                throw new Exception("Area of study not found");
            }
            return areaOfStudy.Id;
        }


        public async Task<List<AreaOfStudy>> GetAreasOfStudyAsync()
        {
            try
            {
                var areas = await _dbContext.AreasOfStudy.ToListAsync();
                if (areas != null)
                {
                    return areas;
                }
                else
                {
                    throw new Exception("can't find areas of study");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
