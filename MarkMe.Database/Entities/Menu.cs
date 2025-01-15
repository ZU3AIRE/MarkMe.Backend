using MarkMe.Database.Enums;

namespace MarkMe.Database.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public Role Role { get; set; }
    }
}
