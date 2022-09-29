using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    public class Tag
    {
        public string TagId { get; set; }
        public ICollection<Post> Posts { get; set; }

        public List<PostTag> PostTagss { get; set; }

    }
}
