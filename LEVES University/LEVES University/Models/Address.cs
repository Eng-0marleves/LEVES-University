using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "The City is required.")]
        [StringLength(50, ErrorMessage = "The City cannot exceed 50 characters.")]
        public string City { get; set; }


        [Required(ErrorMessage = "The street 1 is required.")]
        [StringLength(50, ErrorMessage = "The address cannot exceed 50 characters.")]
        public string Street1 { get; set; }


        [StringLength(50, ErrorMessage = "The address cannot exceed 50 characters.")]
        public string? Street2 { get; set; }


        [StringLength(50, ErrorMessage = "The Zip cannot exceed 50 characters.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid ZIP code.")]
        public string Zip { get; set; }


        public string UserId { get; set; }


        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
    }
}
