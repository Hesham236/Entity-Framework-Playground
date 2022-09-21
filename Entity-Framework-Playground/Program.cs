using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity_Framework_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();
            var employee = new Employee ();

            _context.Employees.Add(employee);

            _context.SaveChanges();
        }
    }
}