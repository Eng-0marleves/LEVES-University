using System.ComponentModel.DataAnnotations.Schema;

namespace Leves_University.Models
{
    public class FAQs
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
