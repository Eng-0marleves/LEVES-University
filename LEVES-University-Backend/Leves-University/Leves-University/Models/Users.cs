using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Leves_University.Models
{
    public class Users
    {
        [StringLength(10)]
        [Key]
        public string CustomId { get; private set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public byte[]? ProfileImage { get; set; }

        public Users()
        {
            CustomId = GenerateCustomId();
        }

        private string GenerateCustomId()
        {
            long timestamp = DateTime.UtcNow.Ticks;
            return timestamp.ToString().Substring(0, 10);
        }
    }
}
