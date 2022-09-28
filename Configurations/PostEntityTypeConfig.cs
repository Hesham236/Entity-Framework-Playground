using Entity_Framework_Playground.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Playground.Configurations
{
    public class PostEntityTypeConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //to change table name:
            //builder
            //    .ToTable("Postss");

            //to rename schema :
            //builder
            //    .ToTable("Posts", schema: "blog");

            //to ignore creating a table even if you make it a domain model:
            //modelBuilder.Ignore<Post>();
        }
    }
}
