using LEVES_University.Interfaces;
using LEVES_University.OtherObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LEVES_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentInputDto student)
        {
            try
            {
                await _studentService.AddStudentAsync(student);
                return Ok("student added succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/GetAreasOfStudy")]
        public async Task<IActionResult> GetAreasOfStudy()
        {
            try
            {
                var areas = await _studentService.GetAreasOfStudyAsync();
                return Ok(areas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
