using Leves_University.Models;
using Leves_University.Models.DbContext;
using Leves_University.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leves_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly LevesEntities _context;

        public FacultiesController(LevesEntities context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("seed_faculties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SeedFacultiesAndDepartments()
        {
            var predefinedFaculties = new List<(string FacultyName, string[] DepartmentNames)>
            {
                ("Engineering", new string[] { "Computer Science", "Electrical Engineering", "Mechanical Engineering" }),
                ("Arts", new string[] { "History", "Literature", "Visual Arts" }),
                ("Sciences", new string[] { "Biology", "Chemistry", "Physics" })
            };

            foreach (var (FacultyName, DepartmentNames) in predefinedFaculties)
            {
                var faculty = _context.Faculties.FirstOrDefault(f => f.Name == FacultyName);
                if (faculty == null)
                {
                    faculty = new FacultyDto { Name = FacultyName };
                    _context.Faculties.Add(faculty);
                    await _context.SaveChangesAsync();
                }

                foreach (var departmentName in DepartmentNames)
                {
                    var departmentExists = _context.Departments.Any(d => d.Name == departmentName && d.FacultyId == faculty.FacultyId);
                    if (!departmentExists)
                    {
                        var department = new DepartmentDto { Name = departmentName, FacultyId = faculty.FacultyId };
                        _context.Departments.Add(department);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return Ok("Faculties and Departments seeded successfully.");
        }
    }
}
