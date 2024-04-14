using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Leves_University.Models.Dtos
{
    public class FacultyDto
    {
        [Key]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "The faculty name is required.")]
        [StringLength(100, ErrorMessage = "The faculty name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public ICollection<DepartmentDto> Departments { get; set; }
    }
}
