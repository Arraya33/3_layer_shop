using _3_layer_shop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.EF.Configuration
{
    public class ImageToProductConfiguration : IEntityTypeConfiguration<ImageToProduct>
    {
        public void Configure(EntityTypeBuilder<ImageToProduct> builder)
        {
            builder.ToTable("ImagesToProducts").HasOne(itp => itp.Product).WithMany(product => product.Images)
                .HasForeignKey(ptc => ptc.ProductId);
            builder.HasOne(itp => itp.Image).WithMany().HasForeignKey(ptc => ptc.ImageId).OnDelete(DeleteBehavior.Restrict);
            builder.HasKey(ptc => new { ptc.ProductId, ptc.ImageId });
        }
    }
}
