﻿using Entity_Framework_Playground.Models;
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

            //var author = _context.Authors.Find(1);
            //author.LastName = "Ali";

            var category = new Category
            {
                Name = "AHMEDD",
            };
            _context.Categories.Add(category);


            _context.SaveChanges();
        }
    }
}