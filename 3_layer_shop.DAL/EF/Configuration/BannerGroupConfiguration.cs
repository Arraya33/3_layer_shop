using _3_layer_shop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.EF.Configuration
{
    public class BannerGroupConfiguration : IEntityTypeConfiguration<BannerGroup>
    {
        public void Configure(EntityTypeBuilder<BannerGroup> builder)
        {
            builder.ToTable("BannerGroups");
        }
    }
}
