using MarkMe.Database.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMe.Database.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateMarked { get; set; }

        [ForeignKey("User")]
        public int MarkedBy { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
