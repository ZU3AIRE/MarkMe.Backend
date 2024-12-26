using MarkMe.Database.Enums;

namespace MarkMe.Database.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public CourseType Type { get; set; }
        public int Semester { get; set; }
        public int AssignedTo { get; set; }
        public int CreditHours { get; set; }
        public bool IsArchived { get; set; }
    }
}
