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
            
        public DbSet<Employee> Employees { get; set; }
    }
}
