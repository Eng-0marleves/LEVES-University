using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class StudentGradingStatus
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Student Status is Required")]
        [StringLength(50)]
        public string StudentStatus { get; set; }

        public CourseEnrollment CourseEnrollment { get; set; }
    }
}
