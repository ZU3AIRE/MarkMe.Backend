using System.ComponentModel.DataAnnotations;

namespace MarkMe.Database.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(4, ErrorMessage = "College roll no cannot be longer than 4 characters.")]
        public string CollegeRollNo { get; set; } = string.Empty;

        [StringLength(6, ErrorMessage = "University roll no cannot be longer than 6 characters.")]
        public string UniversityRollNo { get; set; } = string.Empty;

        [StringLength(12, ErrorMessage = "Registration no cannot be longer than 12 characters.")]
        public string RegistrationNo { get; set; } = string.Empty;

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public Guid PersonId { get; set; } = Guid.Empty;

        [StringLength(9, ErrorMessage = "Session cannot be longer than 9 characters.")]
        public string Session { get; set; } = string.Empty;

        [StringLength(9)]
        public string Section { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
