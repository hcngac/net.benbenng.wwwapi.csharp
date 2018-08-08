using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net.benbenng.wwwapi.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public DateTime CreatedTime { get; set; }
        public List <Content> Updates { get; set; }
        public List <Tagging> Taggings { get; set; }
    }
}
