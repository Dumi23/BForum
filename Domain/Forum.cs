using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Forum: BaseClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string PictureURL { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        

    }
}