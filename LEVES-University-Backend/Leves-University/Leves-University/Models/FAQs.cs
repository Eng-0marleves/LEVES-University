using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class FAQs
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Content { get; set; }
    }

}
