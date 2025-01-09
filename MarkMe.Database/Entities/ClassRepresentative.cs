using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMe.Database.Entities
{
    public class ClassRepresentative
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int IsDeleted { get; set; }

        [ForeignKey("User")]
        public int NominatedBy { get; set; }

        public ICollection<Activity> Activities { get; set; }
        public bool IsDisabled { get; set; } = false;
    }
}
