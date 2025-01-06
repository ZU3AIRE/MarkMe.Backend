using MarkMe.Database.Enums;

namespace MarkMe.Core.DTOs
{
    public class CreateCourseDTO
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public CourseType Type { get; set; }
        public int Semester { get; set; }
        public int CreditHours { get; set; }
        public int CreditHoursPerWeek { get; set; }
    }

    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public CourseType Type { get; set; }
        public int Semester { get; set; }
        public int CreditHours { get; set; }
        public int CreditHoursPerWeek { get; set; }
    }
}
