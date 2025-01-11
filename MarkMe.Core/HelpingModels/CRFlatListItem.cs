namespace MarkMe.Core.HelpingModels
{
    internal class CRFlatListItem
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime? ActivityDate { get; set; } = null;
        public bool IsDisabled { get; set; }
    }
}
