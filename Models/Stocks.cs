using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    public class Stocks
    {
        public int id { get; set; }
        public string stock_name { get; set; }
        public int stock_count { get; set; }
    }
}
