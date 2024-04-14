using System.ComponentModel.DataAnnotations;

namespace Leves_University.Models.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
