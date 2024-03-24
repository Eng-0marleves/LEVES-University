    using System.ComponentModel.DataAnnotations;
    namespace Leves_University.Models
    {
        public class Login
        {
            [Required]
            public int Id { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }
