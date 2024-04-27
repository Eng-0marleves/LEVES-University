using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class College
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The college name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<AreaOfStudy> AreasOfStudy { get; set; }
    }
}
