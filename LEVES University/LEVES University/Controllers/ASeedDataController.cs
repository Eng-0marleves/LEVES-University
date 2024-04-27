using LEVES_University.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LEVES_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ASeedDataController : ControllerBase
    {
        private readonly ISeedDataService _seedDataService;

        public ASeedDataController(ISeedDataService seedDataService)
        {
            _seedDataService = seedDataService;
        }

        [HttpPost("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            await _seedDataService.SeedRolesAsync();
            return Ok("Roles seeded successfully.");
        }


        [HttpPost("seed-users")]
        public async Task<IActionResult> SeedUsers()
        {
            await _seedDataService.SeedUsersAsync();
            return Ok("Users seeded successfully.");
        }


        [HttpPost("seed-colleges")]
        public async Task<IActionResult> SeedColleges()
        {
            await _seedDataService.SeedCollegesAsync();
            return Ok("Colleges seeded successfully.");
        }


        [HttpPost("seed-areas-of-study")]
        public async Task<IActionResult> SeedAreasOfStudy()
        {
            await _seedDataService.SeedAreasOfStudyAsync();
            return Ok("Areas of study seeded successfully.");
        }


        [HttpPost("seed-courses")]
        public async Task<IActionResult> SeedCourses()
        {
            await _seedDataService.SeedCoursesAsync();
            return Ok("Courses seeded successfully.");
        }

        [HttpGet("get-courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _seedDataService.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpPost("seed-students")]
        public async Task<IActionResult> SeedStudents()
        {
            
            await _seedDataService.SeedStudentsAsync();
            return Ok("Students Added Successfxully");
        }
    }
}
