using Leves_University.Models;
using Leves_University.Models.DbContext;
using Leves_University.Models.Dtos;
using Leves_University.Models.OtherObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Leves_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly LevesEntities _context;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            LevesEntities context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }




        #region Seed Roles
        [HttpPost]
        [Route("seed_roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var roles = new[] { StaticUserRoles.STUDENT, StaticUserRoles.MANAGER, StaticUserRoles.ADMIN, StaticUserRoles.DOCTOR, StaticUserRoles.LIBRARIAN };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            return Ok("Roles seeded successfully.");
        }
        #endregion




        #region Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var roleExists = await _roleManager.RoleExistsAsync(model.Role);
            if (!roleExists)
            {
                return BadRequest($"Role '{model.Role}' does not exist.");
            }

            var faculty = await _context.Faculties.FindAsync(model.FacultyId);
            if (faculty == null)
            {
                return BadRequest("Faculty does not exist.");
            }

            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == model.DepartmentId && d.FacultyId == model.FacultyId);
            if (department == null)
            {
                return BadRequest("Department does not exist within the given faculty.");
            }

            var userByEmail = await _userManager.FindByEmailAsync(model.Email);
            var userByPhoneNumber = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
            var userByNationalId = await _userManager.Users.FirstOrDefaultAsync(u => u.NationalId == model.NationalId);

            if (userByEmail != null || userByPhoneNumber != null || userByNationalId != null)
            {
                return BadRequest("User with the given details already exists.");
            }

            var userName = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString().Substring(0, 10);

            //var defaultProfileImage = await System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("C:/Users/Omar/Pictures/profile image.webp"));

            var user = new ApplicationUser
            {
                UserName = userName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                NationalId = model.NationalId,
                Address = model.Address,
                IsActive = true,
                //ProfileImage = defaultProfileImage
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            await _userManager.AddToRoleAsync(user, model.Role);

            // If role is student, create a GPA record with the current active semester
            if (model.Role == StaticUserRoles.STUDENT)
            {
                var activeSemester = await _context.Semesters.FirstOrDefaultAsync(s => s.IsActive);
                if (activeSemester != null)
                {
                    _context.GPARecords.Add(new GPARecord
                    {
                        StudentId = user.Id,
                        GPA = 0.0,
                        SemesterId = activeSemester.Id
                    });
                    await _context.SaveChangesAsync();
                }
            }

            return Ok("Created Successfully");
        }
        #endregion




        #region Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user is null)
                return Unauthorized("Invalid Credentials");

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordCorrect)
                return Unauthorized("Invalid Credentials");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GenerateNewJsonWebToken(authClaims);

            return Ok(token);
        }


        private string GenerateNewJsonWebToken(List<Claim> claims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var tokenObject = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;

        }
        #endregion



        //#region Authorize
        //[HttpGet]
        //[Route("GetStudentRole")]
        //[Authorize(Roles = StaticUserRoles.STUDENT)]
        //public IActionResult GetUserRole()
        //{
        //    return Ok(StaticUserRoles.STUDENT);
        //}


        //[HttpGet]
        //[Route("GetAdmintRole")]
        //[Authorize(Roles = StaticUserRoles.ADMIN)]
        //public IActionResult GetAdminRole()
        //{
        //    return Ok(StaticUserRoles.ADMIN);
        //}


        //[HttpGet]
        //[Route("GetStudentRole")]
        //[Authorize(Roles = StaticUserRoles.DOCTOR)]
        //public IActionResult GetDoctorRole()
        //{
        //    return Ok(StaticUserRoles.DOCTOR);
        //}
        //#endregion




        #region Update Permission
        [HttpPost]
        [Route("make-manager")]
        public async Task<IActionResult> MakeManager([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByNameAsync(updatePermissionDto.UserName);

            if (user is null)
                return BadRequest("Invalid User Name!");

            await _userManager.AddToRoleAsync(user, StaticUserRoles.MANAGER);

            return Ok("User is now an Admin");
        }
        #endregion
    }
}
