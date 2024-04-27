using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    [Index(nameof(CourseCatalogue.CourseCode), IsUnique = true)]
    public class CourseCatalogue
    {
        [Key]
        public int CourseNumber { get; set; }

        [Required(ErrorMessage = "Course code is required.")]
        [StringLength(10)]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course title is required.")]
        [StringLength(50)]
        public string CourseTitle { get; set; }

        [Required(ErrorMessage = "Course description is required.")]
        [StringLength(250)]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "Credit hours is required.")]
        [Range(1, 10, ErrorMessage = "Credit hours must be between 1 and 10.")]
        public int CreditHours { get; set; }

        public ICollection<CourseSchedule> CourseSchedules { get; set; }
    }
}
