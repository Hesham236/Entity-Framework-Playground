using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    public class Blog
    {
        public int Id { get; set; }
        //change name
        //[Column("BlogUrl")]

        //change datatype
        //[Column(TypeName ="varchar(200)")]
        public string? Url { get; set; }
        //execluded prop from table
        //[NotMapped]
        public DateTime? Addedon { get; set; }

        //execlude table from database 
        //[NotMapped]

        //make domain model in database 
        public List<Post> Posts { get; set; }
    }
}
