using Microsoft.AspNetCore.Mvc;
using LEVES_University.Interfaces;
using System.Threading.Tasks;
using LEVES_University.DBContext;
using LEVES_University.Models;
using Microsoft.AspNetCore.Http;
using LEVES_University.OtherObjects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LEVES_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly LevesEntities _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AuthController(IAuthService authService, LevesEntities dbContext, IWebHostEnvironment hostEnvironment)
        {
            _authService = authService;
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var authResult = await _authService.AuthenticateUserAsync(loginRequest.Id, loginRequest.Password);

            if (authResult.StartsWith("User not found"))
            {
                return NotFound("User not found");
            }
            else if (authResult.StartsWith("User is not active"))
            {
                return BadRequest("User is not active");
            }
            else if (authResult.StartsWith("Invalid password"))
            {
                return BadRequest("Invalid password");
            }
            else
            {
                //var cookieOptions = new CookieOptions
                //{
                //    HttpOnly = true,
                //    Secure = true,
                //    Expires = DateTime.UtcNow.AddMinutes(2),
                //    SameSite = SameSiteMode.None
                //};

                //Response.Cookies.Append("user-auth-token", authResult, cookieOptions);

                return Ok(authResult);
            }
        }


        [HttpPost("update-profile-picture")]
        public async Task<IActionResult> UpdateProfilePicture([FromForm] UserProfilePictureRequestDto pictureRequest)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(pictureRequest.UserId);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                var existingPicture = await _dbContext.UsersProfilePicture.FirstOrDefaultAsync(up => up.UserId == pictureRequest.UserId);
                if (existingPicture == null)
                {
                    // Insert new picture
                    var newPicture = new UserProfilePicture
                    {
                        UserId = pictureRequest.UserId,
                        ImageName = pictureRequest.ImageName,
                        ImagePath = _authService.SaveImage(pictureRequest.Image)
                    };
                    _dbContext.UsersProfilePicture.Add(newPicture);
                }
                else
                {
                    // Update existing picture
                    existingPicture.ImageName = pictureRequest.ImageName;
                    existingPicture.ImagePath = _authService.SaveImage(pictureRequest.Image);

                    // Or if you prefer to delete and insert a new row
                    // _dbContext.UserProfilePicture.Remove(existingPicture);
                    // existingPicture.ImagePath = SaveImage(pictureRequest.Image);
                    // _dbContext.UserProfilePicture.Add(existingPicture);
                }

                await _dbContext.SaveChangesAsync();
                return Ok("Profile picture updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error" + ex.Message);
            }
        }
    }
}
