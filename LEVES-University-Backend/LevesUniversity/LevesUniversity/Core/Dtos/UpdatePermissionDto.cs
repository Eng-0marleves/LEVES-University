
using System.ComponentModel.DataAnnotations;

namespace LevesUniversity.Core.Dtos
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "Id is Required")]
        public int Id { get; set; }
    }
}
