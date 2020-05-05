using _3_layer_shop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.EF.Configuration
{
    public class InformationConfiguration : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.HasOne(p => p.Page).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
