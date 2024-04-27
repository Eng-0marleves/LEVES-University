using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Building name is required.")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
