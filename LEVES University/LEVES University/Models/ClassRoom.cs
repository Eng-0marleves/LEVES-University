using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEVES_University.Models
{
    public class ClassRoom
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Building))]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        [Required(ErrorMessage = "Room code is required.")]
        [StringLength(10)]
        public string RoomCode { get; set; }

        [Required(ErrorMessage = "Max seating is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Max seating must be greater than 0.")]
        public int MaxSeating { get; set; }
    }
}
