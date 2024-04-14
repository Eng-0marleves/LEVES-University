namespace Leves_University.Models.Dtos
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EnrollingStartDate { get; set; }
        public DateTime EnrollingEndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
