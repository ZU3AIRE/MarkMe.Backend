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
    }

    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int CourseId { get; set; }
        public List<int> StudentIds { get; set; }
    }

    public class UpdateAttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }

    public class BulkDeleteAttendanceDTO
    {
        public List<int> AttendanceIds { get; set; }
    }
}
