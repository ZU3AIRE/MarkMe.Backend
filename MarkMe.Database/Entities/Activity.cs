using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Database.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // Foreign key to ClassRepresentative
        public int ClassRepresentativeStudentId { get; set; }
        public int ClassRepresentativeCourseId { get; set; }

        //// Navigation property for the one-to-many relationship
        //[ForeignKey("ClassRepresentativeStudentId, ClassRepresentativeCourseId")]
        //public ClassRepresentative ClassRepresentative { get; set; }
    }
}
