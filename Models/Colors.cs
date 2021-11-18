using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace the_other_balloon_widget.Models
{
    public class Colors : IColors
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Counter { get; set; }
        public string Type { get; set; }
        public DateTime Timestamp { get; set; }
    }
}