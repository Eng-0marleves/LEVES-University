using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    public class CourseSchedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CourseCatalogue))]
        public int CourseNumber { get; set; }

        public CourseCatalogue CourseCatalogue { get; set; }

        [ForeignKey(nameof(Semester))]
        public int SemesterId { get; set; }
        public SemesterInfo Semester { get; set; }

        [Required(ErrorMessage = "Number of seats is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of seats must be at least 1.")]
        public int NumberOfSeats { get; set; }

        [ForeignKey(nameof(ClassRoom))]
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }

        public ICollection<CourseDailySchedule> DailySchedules { get; set; }
    }
}
