using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    public class CourseEnrollment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CourseSchedule")]
        public int CourseScheduleId { get; set; }
        public CourseSchedule CourseSchedule { get; set; }

        [ForeignKey("CourseScheduleId")]
        public ICollection<StudentInfo> EnrolledStudents { get; set; }

        [ForeignKey("CourseScheduleId")]
        public ICollection<StudentGradingStatus> GradingStatuses { get; set; }

        [ForeignKey("CourseScheduleId")]
        public ICollection<Grades> Grades { get; set; }
    }
}
