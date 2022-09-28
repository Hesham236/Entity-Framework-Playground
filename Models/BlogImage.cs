using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    public class BlogImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required,MaxLength(100)]
        public string caption { get; set; }
        public int BlogForeignKey { get; set; }
        [ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }
    }
}
