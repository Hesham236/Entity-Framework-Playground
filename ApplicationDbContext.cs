using Entity_Framework_Playground.Configurations;
using Entity_Framework_Playground.Models;
using Microsoft.EntityFrameworkCore;


namespace Entity_Framework_Playground
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = EFCore; Integrated Security = True"); //HomeDatabase:
            //options.UseSqlServer(@"Data Source = (localdb)\ProjectModels; Initial Catalog = EFCore; Integrated Security = True"); //GehazDatabase
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //call the model that make you configure properties
            new BlogEntityTypeConfig().Configure(modelBuilder.Entity<Blog>());
            new AuthorEntityTypeConfig().Configure(modelBuilder.Entity<Author>());
            new PostEntityTypeConfig().Configure(modelBuilder.Entity<Post>());
            new BookEntityTypeConfig().Configure(modelBuilder.Entity<Book>());
            new CategoryEntityTypeConfig().Configure(modelBuilder.Entity<Category>());
            new BlogImageEntityTypeConfig().Configure(modelBuilder.Entity<BlogImage>());
            new PersonEntityTypeConfig().Configure(modelBuilder.Entity<Person>());
        }
        //domain tables
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<AuditEntery>? Auditenteries { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<BlogImage>? BlogImages { get; set; }
        public DbSet<Person>? Persons { get; set; }
    }
    //Three ways to add domain model
    //1-public DbSet<Blog> Blogs { get; set; } ----> gowa el DbContext as a public
    //2-modelBuilder.Entity<AuditEntery>(); ----> gowa func modelbuilder
    //3-public List<Post> Posts { get; set; } ----> gowa table domain
}
