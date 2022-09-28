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
    public class BlogImageEntityTypeConfig : IEntityTypeConfiguration<BlogImage>
    {
        public void Configure(EntityTypeBuilder<BlogImage> builder)
        {
            
        }
    }
}
