using _3_layer_shop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.EF.Configuration
{
    public class ProductToCategoryConfiguration : IEntityTypeConfiguration<ProductToCategory>
    {
        public void Configure(EntityTypeBuilder<ProductToCategory> builder)
        {
            builder.ToTable("ProductsToCategories").HasOne(ptc => ptc.Product).WithMany(product => product.ProductToCategories)
                .HasForeignKey(ptc => ptc.ProductId);
            builder.HasOne(ptc => ptc.ProductCategory).WithMany(pc => pc.ProductToCategories)
                .HasForeignKey(ptc => ptc.ProductCategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasKey(ptc => new { ptc.ProductId, ptc.ProductCategoryId });
        }
    }
}
