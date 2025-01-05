using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MarkMe.Database.Enums;

namespace MarkMe.Database.Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        [StringLength(6, ErrorMessage = "Code cannot be longer than 6 characters.")]
        public string Code { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; } = string.Empty;
        public CourseType Type { get; set; }
        public int Semester { get; set; }
        public int CreditHours { get; set; }
        public int CreditHoursPerWeek { get; set; }
        public bool IsArchived { get; set; }

        [ForeignKey("User")]
        public int AssignedTo { get; set; }
    }
}
