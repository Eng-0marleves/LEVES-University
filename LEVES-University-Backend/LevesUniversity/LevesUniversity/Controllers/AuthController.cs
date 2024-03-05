using LevesUniversity.Core.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace LevesUniversity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("seed_roles")]
        public async Task<IActionResult> SeedRoles()
        {
            bool isStudent = await _roleManager.RoleExistsAsync(StaticUserRoles.STUDENT);
            bool isDoctor = await _roleManager.RoleExistsAsync(StaticUserRoles.DOCTOR);
            bool isManager = await _roleManager.RoleExistsAsync(StaticUserRoles.MANAGER);

            if (isStudent && isDoctor && isManager)
                return Ok("Role Seeding is Already Done");

            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.STUDENT));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.DOCTOR));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.MANAGER));

            return Ok("Role Seeding Done Successfully");
        }
    }
}
