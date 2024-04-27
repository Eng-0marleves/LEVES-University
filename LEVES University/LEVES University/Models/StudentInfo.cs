using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    [Index(nameof(StudentId), IsUnique = true)]
    public class StudentInfo
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 7, ErrorMessage = "Grade must be between 1 and 6.")]
        public int Grade { get; set; } = 1;

        [Range(0, 4.0, ErrorMessage = "GPA must be between 0 and 4.0.")]
        public double GPA { get; set; } = 4.0;

        [ForeignKey("User")]
        public string? StudentId { get; set; }
        public Users? User { get; set; }

        
        [ForeignKey("AreaOfStudy")]
        public int AreaOfStudyId { get; set; }
        public AreaOfStudy? AreaOfStudy { get; set; }

        public ICollection<CourseEnrollment>? Courses { get; set; }
    }
}