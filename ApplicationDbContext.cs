using Entity_Framework_Playground.Configurations;
using Entity_Framework_Playground.Models;
using Microsoft.EntityFrameworkCore;


namespace Entity_Framework_Playground
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        //HomeDatabase:
        //options.UseSqlServer("");
        //GehazDatabase:
            options.UseSqlServer(@"Data Source = (localdb)\ProjectModels; Initial Catalog = EFCore; Integrated Security = True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //to call the model that make you configure properties in blog table
            new BlogEntityTypeConfig().Configure(modelBuilder.Entity<Blog>());

            //making table AuditEntery domain model 
            modelBuilder.Entity<AuditEntery>();

            //to ignore creating a table even if you make it a domain model:
            //modelBuilder.Ignore<Post>();

            //to execlude migrations to update on certain table after creating it:
            //modelBuilder.Entity<Blog>()
            //    .ToTable("Blogs", m => m.ExcludeFromMigrations());

            //to change table name:
            //modelBuilder.Entity<Post>()
            //    .ToTable("Postss");

            //to rename schema :
            //modelBuilder.Entity<Post>()
            //    .ToTable("Posts", schema: "blog");

            //to make default schema for all next tables:
            //modelBuilder.HasDefaultSchema("blog");

            //to make property execluded from table:
            //modelBuilder.Entity<Blog>()
            //    .Ignore(b => b.Addedon);

            //change column name in DB
            //modelBuilder.Entity<Blog>()
            //    .Property(e => e.Url)
            //    .HasColumnName("BlobUrl");

            //change column datatype
            //modelBuilder.Entity<Blog>(eb =>
            //{
            //    eb.Property(b => b.Url).HasColumnType("varchar(200)");
            //});

            ////make BookKey a PrimaryKey and change its name
            //modelBuilder.Entity<Book>()
            //    .HasKey(e => e.BookKey)
            //    .HasName("PK_BookKey");

            //make composite key
            modelBuilder.Entity<Book>()
              .HasKey(e => new { e.Name, e.author });

            //make default value
            modelBuilder.Entity<Blog>()
                .Property(e => e.Rating)
                .HasDefaultValue(2);

            modelBuilder.Entity<Blog>()
              .Property(e => e.Addedon)
              .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Author>()
                .Property(e => e.DisplayName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

        }
        //to make blog table domain
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }



    //3 ways to add domain model

    //1-public DbSet<Blog> Blogs { get; set; } ----> gowa el DbContext as a public
    //2-modelBuilder.Entity<AuditEntery>(); ----> gowa func modelbuilder
    //3-public List<Post> Posts { get; set; } ----> gowa table domain
}
