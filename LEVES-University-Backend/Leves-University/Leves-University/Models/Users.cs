using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Leves_University.Models
{
    public enum UserType
    {
        Student,
        Teacher,
        Admin
    }

    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomId { get; private set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; private set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "User type is required.")]
        public UserType UserType { get; set; }

        // Nullable Profile Image property
        public byte[]? ProfileImage { get; set; }

        public Users()
        {
            CustomId = GenerateCustomId();
            Password = GeneratePassword();
        }

        private string GenerateCustomId()
        {
            long timestamp = DateTime.UtcNow.Ticks;
            string id = timestamp.ToString().Substring(0, 10);
            return id;
        }

        private string GeneratePassword()
        {
            var firstChar = FirstName.FirstOrDefault();
            var specialChars = "!@";
            var numbers = "12";

            var passwordBuilder = new StringBuilder();
            passwordBuilder.Append(firstChar)
                            .Append(specialChars)
                            .Append(numbers)
                            .Append('A') // Ensure at least one uppercase character
                            .Append('a') // Ensure at least one lowercase character
                            .Append(CustomId); // Include CustomId for uniqueness

            return passwordBuilder.ToString();
        }
    }
}
