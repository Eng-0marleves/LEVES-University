using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LEVES_University.Models
{
    public class JopInformation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Job Description is required.")]
        [StringLength(250, ErrorMessage = "The Job Description cannot exceed 250 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Requirements are required.")]
        [StringLength(250, ErrorMessage = "The Requirements cannot exceed 250 characters.")]
        public string Requirements { get; set; }

        [Required(ErrorMessage = "The minimum pay is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum pay must be a non-negative value.")]
        public double MinPay { get; set; }

        [Required(ErrorMessage = "The maximum pay is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Maximum pay must be a non-negative value.")]
        [Compare(nameof(MinPay), ErrorMessage = "Maximum pay must be greater than or equal to minimum pay.")]
        public double MaxPay { get; set; }

        public ICollection<EmployeeInfo> Employees { get; set; }
    }
}
