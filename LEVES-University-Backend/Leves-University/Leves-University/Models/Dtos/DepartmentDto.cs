using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Leves_University.Models.Dtos
{
    public class DepartmentDto
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The department name is required.")]
        [StringLength(100, ErrorMessage = "The department name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The faculty ID is required.")]
        public int FacultyId { get; set; }

        public FacultyDto Faculty { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }
}
