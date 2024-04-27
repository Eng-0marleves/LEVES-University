using System.ComponentModel.DataAnnotations;

namespace LEVES_University.OtherObjects
{
    public class StudentInputDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long NTID { get; set; }
        public string AreaOfStudy { get; set; }
        public string City { get; set; }
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        public string Zip { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
