using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Models
{
    public class AuditEntery
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Action { get; set; }
    }
}
