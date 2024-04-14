using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models.Dtos
{
    public class GPARecord
    {
        [Key]
        public int Id { get; set; }
        public double GPA { get; set; }

        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public ApplicationUser Student { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
    }
}
