using LEVES_University.Interfaces;
using LEVES_University.Models;
using LEVES_University.OtherObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LEVES_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;

        }

        [HttpGet]
        [Route("/Semesters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<SemesterInfo>> GetAllSemesters()
        {
            var semesters = _semesterService.GetAllSemesters();
            return Ok(semesters);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SemesterInfo> GetSemester(int id)
        {
            var semester = _semesterService.GetSemesterById(id);

            if (semester == null)
            {
                return NotFound();
            }

            return Ok(semester);
        }


        [HttpPost]
        [Route("/AddSemester")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddSemester([FromBody] SemesterInfo semester)
        {
            _semesterService.AddSemester(semester);
            return CreatedAtAction("GetSemester", new { id = semester.Id }, semester);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditSemester(int id, [FromBody] SemesterInfo semester)
        {
            if (id != semester.Id)
            {
                return BadRequest();
            }

            _semesterService.EditSemester(semester);

            return NoContent();
        }


        [HttpGet]
        [Route("/CurrentSemester")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentSemester()
        {
            var semeseter = await _semesterService.GetLastSemester();
            return Ok(semeseter);
        }



        [HttpGet]
        [Route("/GetSemesterCourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSemesterCourses()
        {
            var semesterCourses = await _semesterService.GetSemesterCourses();


            return Ok(semesterCourses);
        }



        [HttpPost]
        [Route("/AddSemesterCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSemesterCourse([FromQuery] SemesterCourseInputModel course)
        {
            try
            {
                if (course != null)
                {
                    await _semesterService.AddSemesterCourseAsync(course);
                    return Ok("Course added successfully.");
                }
                else
                {
                    return BadRequest("Invalid course data.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        [HttpDelete]
        [Route("/DeleteSemesterCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSemesterCourse([FromQuery] int id)
        {
            try
            {
                await _semesterService.RemoveSemesterCourseAsync(id);
                return Ok("Semester course deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


        [HttpGet]
        [Route("/GetUnAvilableCoursesInSemester")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUnAvilableCoursesInSemester()
        {
            try
            {
                var courses = await _semesterService.GetUnavailableCoursesInSemester(   );
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
