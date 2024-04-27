using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "The role name is required.")]
        [StringLength(50, ErrorMessage = "The role name cannot exceed 50 characters.")]
        public string Name { get; set; }

        public ICollection<Users> Users { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
