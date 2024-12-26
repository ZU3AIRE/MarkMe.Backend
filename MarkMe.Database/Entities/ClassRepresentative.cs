namespace MarkMe.Database.Entities
{
    public class ClassRepresentative
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int NominatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
