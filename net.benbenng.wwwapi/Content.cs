using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net.benbenng.wwwapi
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastEditedTime { get; set; }
        public bool ShownInBlogs { get; set; }
        public Project Project { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
