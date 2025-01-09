namespace MarkMe.Core.DTOs
{
    public class CRDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<SelectItem> Courses { get; set; }
        public List<ActivityDTO> Activities { get; set; }
        public string Avatar { get; set; }
        public bool IsDisabled { get; set; }
    }
}
