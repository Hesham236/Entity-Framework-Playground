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
    public class BookEntityTypeConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            ////make BookKey a PrimaryKey and change its name
            //builder
            //    .HasKey(e => e.BookKey)
            //    .HasName("PK_BookKey");

            //make composite key
            builder
              .HasKey(e => new { e.Name, e.author });
        }
    }
}
