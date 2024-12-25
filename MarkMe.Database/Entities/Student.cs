namespace MarkMe.Database.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string CollegeRollNo { get; set; } = string.Empty;
        public string UniversityRollNo { get; set; } = string.Empty;
        public string RegistrationNo { get; set; } = string.Empty;
        public string Session { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
