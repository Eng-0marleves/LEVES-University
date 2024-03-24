using Leves_University.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using System.Linq;

namespace Leves_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LevesEntities context;
        private readonly JwtService _jwtService;

        public AuthController(LevesEntities context, JwtService jwtService)
        {
            this.context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login(Login login)
        {
            var user = this.context.Login.FirstOrDefault(l => l.Id == login.Id);

            if (user != null && user.Password.Equals(login.Password))
            {
                // Generate JWT token
                var token = _jwtService.GenerateJwtToken(user.Id);
                return Ok(new { Token = token });
            }
            else
            {
                return BadRequest("Invalid ID or password.");
            }
        }
    }
}
