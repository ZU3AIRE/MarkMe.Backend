using System.ComponentModel.DataAnnotations;

namespace MarkMe.Database.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
