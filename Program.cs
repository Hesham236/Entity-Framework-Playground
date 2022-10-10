using Entity_Framework_Playground.Models;
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
            //var category = new Category
            //{
            //    Name = "AHMEDD",
            //};
            //_context.Categories.Add(category);
            //SeedData();

            //var stocks = _context.Stocks.ToList();

            //foreach(var stock in stocks)
            //    Console.WriteLine(stock.stock_name);

            //var stock = _context.Stocks.Find(100);
            //Console.WriteLine($"ID: {stock.id} : {stock.stock_name}");

            //var stock = _context.Stocks.FirstOrDefault(m => m.id > 100); //to select first element with id bigger than 100 if not found then return default wich is no item found
            //Console.WriteLine(stock == null ? "No Items Found" : $"ID :{stock.id} {stock.stock_name}");

            //var stock = _context.Stocks.OrderBy(m => m.id).Last(); 
            //Console.WriteLine(stock == null ? "No Items Found" : $"ID :{stock.id} {stock.stock_name}");

            
            _context.SaveChanges();
        }

        public static void SeedData()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
                var blog = context.Blogs.FirstOrDefault(b => b.Url =="www.chroom.com");
                if (blog == null)
                    context.Blogs.Add(new Blog { Url = "www.chroom.com" });
                context.SaveChanges();
            }
        }
    }
}