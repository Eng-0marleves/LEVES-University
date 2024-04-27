using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    public class EmployeeInfo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Yearly pay is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Yearly pay must be a non-negative value.")]
        public double YearlyPay { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public Users User { get; set; }


        [ForeignKey("JopInformation")]
        public int JopInformationId { get; set; }
        public JopInformation JopInformation { get; set; }
    }
}
