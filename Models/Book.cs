using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    public class Book
    {
        //set bookKey as a primaryKey
        //[Key]
        public int BookKey { get; set; } 
        public string Name { get; set; }    
        public string author { get; set; }
    }
}
