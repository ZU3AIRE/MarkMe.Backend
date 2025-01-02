using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MarkMe.Database.Enums;

namespace MarkMe.Database.Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        [StringLength(6)]
        public string Code { get; set; } = string.Empty;

        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        public CourseType Type { get; set; }

        [StringLength(50)]
        public int Semester { get; set; }

        public int CreditHours { get; set; }
        public int CreditPerHoursWeek { get; set; }
        public bool IsArchived { get; set; }


        [ForeignKey("User")]
        public int AssignedTo { get; set; }

        [ForeignKey("User")]
        public string TeacherId { get; set; }
    }
}
