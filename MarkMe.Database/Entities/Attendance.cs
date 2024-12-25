namespace MarkMe.Database.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateMarked { get; set; }
        public int MarkedBy { get; set; }
    }
}
