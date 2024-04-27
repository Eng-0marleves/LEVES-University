using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    public class SemesterCourse
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Semester")]
        //public int SemesterId { get; set; }
        //public SemesterInfo Semester { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public CourseCatalogue Course { get; set; }
    }
}
