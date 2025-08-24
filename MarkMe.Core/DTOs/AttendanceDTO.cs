using MarkMe.Database.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.DTOs
{
    public class AddAttendanceDTO
    {
        public int CourseId { get; set; }
        public string StudentsRollNos { get; set; }
        public DateTime DateMarked { get; set; }
        public int Status { get; set; }
    }

    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int CourseId { get; set; }
        public List<int> StudentIds { get; set; }
        public DateTime DateMarked { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
    }

    public class UpdateAttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateMarked { get; set; }
        public int AttendanceStatus { get; set; }
    }

    public class BulkDeleteAttendanceDTO
    {
        public List<int> AttendanceIds { get; set; }
    }

    public class PromptAttendance
    {
        public string Prompt { get; set; }
    }

    public class StudentImages
    {
        public string StudentId { get; set; }
        public IFormFile[] Images { get; set; }
    }
}
