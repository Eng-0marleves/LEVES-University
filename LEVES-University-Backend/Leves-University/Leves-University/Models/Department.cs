using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("College")]
        public int CollegeId { get; set; }
        public College College { get; set; }
    }
}