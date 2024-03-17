using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserType { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        public byte[] ProfileImage { get; set; }
        [Required]
        [MaxLength(20)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        
        [ForeignKey("Department")]
        public int Dept { get; set; }
        public Department Department { get; set; }
    }
}
