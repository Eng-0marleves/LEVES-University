using System.ComponentModel.DataAnnotations;

namespace Leves_University.Models.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Faculty is Required")]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        public string Role { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "National ID is Required")]
        public string NationalId { get; set; }

        public string Address { get; set; }
    }
}
