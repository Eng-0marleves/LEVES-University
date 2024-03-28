using System.ComponentModel.DataAnnotations;

namespace Leves_University.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
