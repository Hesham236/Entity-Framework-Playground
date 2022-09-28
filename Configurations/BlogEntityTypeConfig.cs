using Entity_Framework_Playground.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Configurations
{
    public class BlogEntityTypeConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
                .Property(m => m.Url)
                .IsRequired();

            ////to execlude migrations to update on certain table after creating it:
            //builder
            //   .ToTable("Blogs", m => m.ExcludeFromMigrations());

            ////to make property execluded from table:
            //builder
            //    .Ignore(b => b.Addedon);

            ////change column name in DB
            //builder
            //    .Property(e => e.Url)
            //    .HasColumnName("BlobUrl");

            ////change column datatype
            //builder
            //  .Property(b => b.Url).HasColumnType("varchar(200)");

            //make default value
            builder
                .Property(e => e.Rating)
                .HasDefaultValue(2);

            builder
              .Property(e => e.Addedon)
              .HasDefaultValueSql("GETDATE()");


            //to make default schema for all next tables:
            //modelBuilder.HasDefaultSchema("blog");

            builder
                .HasOne(b => b.BlogImage)
                .WithOne(i => i.Blog)
                .HasForeignKey<BlogImage>(b => b.BlogForeignKey);
            builder
                .HasMany(b => b.Posts)
                .WithOne();
        }
    }
}
