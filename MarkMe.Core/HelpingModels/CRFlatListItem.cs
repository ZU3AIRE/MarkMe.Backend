namespace MarkMe.Core.HelpingModels
{
    internal class CRFlatListItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime? ActivityDate { get; set; } = null;
    }
}
