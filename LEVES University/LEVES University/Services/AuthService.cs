using LEVES_University.Interfaces;
using LEVES_University.DBContext;
using LEVES_University.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace LEVES_University.Services
{
    public class AuthService: IAuthService
    {
        private readonly LevesEntities _dbContext;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostEnvironment;


        public AuthService(LevesEntities dbContext, IConfiguration config, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _config = config;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> AuthenticateUserAsync(string id, string password)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return "User not found";
            }

            if (!user.IsActive)
            {
                return "User is not active";
            }

            var passwordHasher = new PasswordHasher<Users>();
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (verificationResult == PasswordVerificationResult.Success)
            {
                return GenerateJwtToken(user);
            }
            else
            {
                return "Invalid password";
            }
        }

        private string GenerateJwtToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            // Search for the user's picture
            string imageUrl = _dbContext.UsersProfilePicture
                                          .Where(up => up.UserId == user.Id)
                                          .Select(up => up.ImagePath)
                                          .FirstOrDefault();

            // Include the picture URL or an empty string in the claims
            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim("name", user.FirstName + " " + user.LastName),
                new Claim("email", user.Email),
                new Claim("phone", user.PhoneNumber),
                new Claim("role", _dbContext.Roles.FirstOrDefault(role => role.Id == user.RoleId)?.Name),
            };

            // Include the image claim if the picture exists
            if (!string.IsNullOrEmpty(imageUrl))
            {
                claims.Add(new Claim("image", imageUrl));
            }
            else
            {
                claims.Add(new Claim("image", ""));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(600),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public string SaveImage(IFormFile image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image), "Image file cannot be null");
            }

            // Define the directory where you want to store the images
            var uploadDirectory = Path.Combine(_hostEnvironment.WebRootPath, "uploads");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            // Generate a unique file name for the image
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            // Combine the directory path with the file name
            var filePath = Path.Combine(uploadDirectory, fileName);

            // Write the image file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            // Return the relative file path
            return Path.Combine("uploads", fileName);
        }

    }
}
