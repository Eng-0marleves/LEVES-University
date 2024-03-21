using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public byte[] ProfileImage { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(20)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        [ForeignKey("Department")]
        public int Dept { get; set; }
        public Department Department { get; set; }
    }

}
