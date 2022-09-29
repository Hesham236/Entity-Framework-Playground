using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    //to rename table name in database
    //[Table("Posts")]

    //to rename schema 
    //[Table("Posts",Schema = "blogging")]
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        //public int BlogId { get; set; } 
        //Navigation Property to blog table from posts table making blog a domain and post a child
        //public Blog Blogs { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public List<PostTag> PostTagss { get; set; }
    }
}
