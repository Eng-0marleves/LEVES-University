using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Leves_University.Models.Dtos
{
    public class UserDto: IdentityUser
    {
        [StringLength(50, ErrorMessage = "The first name cannot exceed 50 characters.")]
        public string FirstName { get; set; }
       
        [StringLength(150, ErrorMessage = "The last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0.")]
        public double? GPA { get; set; }

        [Required(ErrorMessage = "The department ID is required.")]
        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }

        [Required(ErrorMessage = "The user type is required.")]
        [StringLength(50, ErrorMessage = "The user type cannot exceed 50 characters.")]
        public string UserType { get; set; }

        public byte[]? ProfileImage { get; set; }
    }
}
