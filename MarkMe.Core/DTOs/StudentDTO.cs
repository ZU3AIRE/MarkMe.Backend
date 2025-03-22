using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; } // Changed from private to public
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CollegeRollNo { get; set; }
        public string UniversityRollNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Session { get; set; }
        public string Section { get; set; }
        public string Email { get; set; }
    }
    public class CreateStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CollegeRollNo { get; set; }
        public string UniversityRollNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Session { get; set; }
        public string Section { get; set; }
        public string Email { get; set; }
    }
}
