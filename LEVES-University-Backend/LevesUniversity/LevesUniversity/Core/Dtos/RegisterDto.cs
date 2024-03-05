using System.ComponentModel.DataAnnotations;

namespace LevesUniversity.Core.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Id is Required")] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
    }
}
