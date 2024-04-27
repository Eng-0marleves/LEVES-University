using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class UserProfilePicture
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }

        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
