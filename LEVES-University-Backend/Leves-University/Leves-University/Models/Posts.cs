using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class Posts
    {
        public int ID { get; set; }
        public string Page { get; set; } 
        public string Content { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
