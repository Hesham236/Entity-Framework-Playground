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
    public class AuthorEntityTypeConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .Property(e => e.DisplayName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
        }
    }
}
