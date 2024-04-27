using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    [Index(nameof(StudyTitle), IsUnique = true)]
    public class AreaOfStudy
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The study title is required.")]
        [StringLength(100, ErrorMessage = "The study title cannot exceed 100 characters.")]
        public string StudyTitle { get; set; }

        [ForeignKey("College")]
        public int CollegeId { get; set; }
        public College College { get; set; }
        public ICollection<StudentInfo> Students { get; set; }

        public ICollection<CourseAreaOfStudy> CourseAreasOfStudy { get; set; }
    }
}