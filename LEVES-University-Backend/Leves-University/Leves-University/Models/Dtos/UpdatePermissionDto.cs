using System.ComponentModel.DataAnnotations;

namespace Leves_University.Models.Dtos
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }
    }
}
