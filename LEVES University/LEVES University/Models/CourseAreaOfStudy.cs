using LEVES_University.Models;
using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class CourseAreaOfStudy
    {
        [Key]
        public int Id { get; set; }

        public int CourseCatalogueId { get; set; }
        public CourseCatalogue CourseCatalogue { get; set; }

        public int AreaOfStudyId { get; set; }
        public AreaOfStudy AreaOfStudy { get; set; }

        [Required(ErrorMessage = "The Grade is Reurired")]
        [Range(1, 7, ErrorMessage = "The value for Grad must be between 1 and 7.")]
        public int Grade { get; set; }
    }
}
