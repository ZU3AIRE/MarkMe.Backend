using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.DTOs
{
    public class FaceGallery
    {
        public List<StudentFaces> Students { get; set; }
    }

    public class StudentFaces
    {
        public string StudentId { get; set; }
        public List<string> Faces { get; set; }
    }
}
