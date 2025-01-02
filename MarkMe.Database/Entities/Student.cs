using System.ComponentModel.DataAnnotations;

namespace MarkMe.Database.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(4)]
        public string CollegeRollNo { get; set; } = string.Empty;

        [StringLength(6)]
        public string UniversityRollNo { get; set; } = string.Empty;

        [StringLength(12)]
        public string RegistrationNo { get; set; } = string.Empty;

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(9)]
        public string Session { get; set; } = string.Empty;

        [StringLength(9)]
        public string Section { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
