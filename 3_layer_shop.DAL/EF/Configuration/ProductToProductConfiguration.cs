using _3_layer_shop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.EF.Configuration
{
    public class ProductToProductConfiguration : IEntityTypeConfiguration<ProductToProduct>
    {
        public void Configure(EntityTypeBuilder<ProductToProduct> builder)
        {
            builder.ToTable("ProductsToProducts").HasOne(ptc => ptc.ProductParent)
                .WithMany(product => product.ProductToProductsChilds).HasForeignKey(ptc => ptc.ProductParentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ptc => ptc.ProductChild).WithMany(product => product.ProductToProductsParents).HasForeignKey(ptc => ptc.ProductChildId);
            builder.HasKey(ptc => new { ptc.ProductChildId, ptc.ProductParentId });
        }
    }
}
