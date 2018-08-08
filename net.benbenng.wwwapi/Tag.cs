using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net.benbenng.wwwapi
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
    }

    public class Tagging
    {
        public int TaggingId { get; set; }
        public Tag Tag { get; set; }
        public Content Content { get; set; }
        public Project Project { get; set; }
    }
}
