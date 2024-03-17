using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class College
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("User")]
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
    }
}