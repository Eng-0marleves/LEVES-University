using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    public class CourseDailySchedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CourseSchedule))]
        public int CourseId { get; set; }
        public CourseSchedule CourseSchedule { get; set; }

        [ForeignKey(nameof(EmployeeInfo))]
        public int DoctorId { get; set; }
        public EmployeeInfo Doctor { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }
    }
}
