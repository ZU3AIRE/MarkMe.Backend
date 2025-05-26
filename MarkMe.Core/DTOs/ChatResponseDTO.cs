using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.DTOs
{
    public class ChatResponseDTO
    {
        public string sql { get; set; }
        public string status { get; set; }
        public string? message { get; set; }
    }
}
