using LEVES_University.DBContext;
using LEVES_University.Interfaces;
using LEVES_University.Models;
using LEVES_University.OtherObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LEVES_University.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly LevesEntities _dbContext;

        public SemesterService(LevesEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SemesterInfo> GetAllSemesters()
        {
            return _dbContext.SemestersInfo.OrderByDescending(s => s.Id).ToList();
        }

        public SemesterInfo? GetSemesterById(int id)
        {
            return _dbContext.SemestersInfo.FirstOrDefault(s => s.Id == id);
        }

        public void AddSemester(SemesterInfo semester)
        {
            _dbContext.SemestersInfo.Add(semester);
            _dbContext.SaveChanges();
        }

        public void EditSemester(SemesterInfo semester)
        {
            _dbContext.Entry(semester).State = EntityState.Modified;
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemesterExists(semester.Id))
                {
                    throw new Exception("Semester not found.");
                }
                else
                {
                    throw;
                }
            }
        }

        

        private bool SemesterExists(int id)
        {
            return _dbContext.SemestersInfo.Any(s => s.Id == id);
        }

        public async Task<SemesterInfo?> GetLastSemester()
        {
            var semester = await _dbContext.SemestersInfo.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
            return semester;
        }


        public void AddSemesterCourse(int semesterId, int courseId)
        {
            var semester = _dbContext.SemestersInfo.Find(semesterId);
            if (semester == null)
            {
                throw new ArgumentException("Invalid semester ID.");
            }

            var course = _dbContext.CoursesCatalogues.Find(courseId);
            if (course == null)
            {
                throw new ArgumentException("Invalid course ID.");
            }

            _dbContext.SaveChanges();
        }


        public async Task<IEnumerable<CourseCatalogue?>> GetSemesterCourses()
        {
            var semester = await this.GetLastSemester();

            var semesterCourses = await _dbContext.SemesterCourses
                .Include(sc => sc.Course)
                .Select(sc => sc.Course)
                .ToListAsync();

            return semesterCourses;
        }


        public async Task AddSemesterCourseAsync(SemesterCourseInputModel course)
        {
            _dbContext.SemesterCourses.Add(new SemesterCourse { CourseId = course.CourseId });
            await _dbContext.SaveChangesAsync();
        }


        public async Task RemoveSemesterCourseAsync(int id)
        {
            var semesterCourseToRemove = await _dbContext.SemesterCourses.FirstOrDefaultAsync(c => c.CourseId == id);
            if (semesterCourseToRemove != null)
            {
                _dbContext.SemesterCourses.Remove(semesterCourseToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<CourseCatalogue>> GetUnavailableCoursesInSemester()
        {
            var unavailableCourses = await _dbContext.CoursesCatalogues
                .Where(course => !_dbContext.SemesterCourses.Any(sc => sc.CourseId == course.CourseNumber))
                .ToListAsync();

            return unavailableCourses;
        }

    }
}
