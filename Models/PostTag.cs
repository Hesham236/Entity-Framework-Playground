using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    public class PostTag
    {
        public string TagId { get; set; }
        public Tag Tag { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
