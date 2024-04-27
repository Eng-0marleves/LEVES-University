using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class Grades
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "The Grade is required")]
        public string Grade { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
