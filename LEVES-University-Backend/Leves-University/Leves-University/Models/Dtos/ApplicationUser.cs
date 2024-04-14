using Microsoft.AspNetCore.Identity;

namespace Leves_University.Models.Dtos
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string NationalId { get; set; }
        public byte[] ProfileImage { get; set; }
        public virtual ICollection<GPARecord> GPARecords { get; set; }
    }
}
