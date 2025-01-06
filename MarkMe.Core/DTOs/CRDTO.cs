using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.DTOs
{
    public class CRDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Courses { get; set; }
        public List<ActivityDTO> Activities { get; set; }
        public string Avatar { get; set; }
    }
}
