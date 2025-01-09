using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.DTOs
{
    public class SelectItem
    {
        public SelectItem(int id, string label)
        {
            Id = id;
            Label = label;
        }

        public int Id { get; set; }
        public string Label { get; set; }

    }
}
