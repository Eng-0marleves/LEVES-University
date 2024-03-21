using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class Posts
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Page { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
    }

}
