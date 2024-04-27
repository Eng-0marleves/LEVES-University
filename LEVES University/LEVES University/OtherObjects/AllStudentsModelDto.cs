using System.ComponentModel.DataAnnotations;

namespace LEVES_University.OtherObjects
{
    public class AllStudentsModelDto
    {
        public string StudentId { get; set; }
        public int Grade { get; set; }
        public int StudentCount { get; set; }
        public double GPA { get; set; }
        public string? AreaOfStudy { get; set; }
        public long NTID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
