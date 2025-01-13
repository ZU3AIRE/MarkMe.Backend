using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.DTOs
{
    public class AttendanceDataModel
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string UniversityRollNo { get; set; }
        public string CollegeRollNo { get; set; }
        public DateTime DateMarked { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int Semester { get; set; }
        public string MarkedBy { get; set; }
        public string Status { get; set; } = "Present";
    }
}
