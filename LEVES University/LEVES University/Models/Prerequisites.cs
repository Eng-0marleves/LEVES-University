using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    [Index(nameof(ParentCourseId), nameof(ChildCourseId), IsUnique = true)]
    public class Prerequisites
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ParentCourse))]
        public int ParentCourseId { get; set; }
        public CourseCatalogue ParentCourse { get; set; }

        [ForeignKey(nameof(ChildCourse))]
        public int ChildCourseId { get; set; }
        public CourseCatalogue ChildCourse { get; set; }

        public bool IsChildCourseOpen { get; set; }
    }
}
