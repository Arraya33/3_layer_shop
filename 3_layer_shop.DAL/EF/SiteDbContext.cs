﻿using _3_layer_shop.DAL.EF.Configuration;
using _3_layer_shop.DAL.Entities;
using _3_layer_shop.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.EF
{
    public class SiteDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<BannerGroup> BannerGroups { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Information> Informations { get; set; }

        public SiteDbContext(DbContextOptions<SiteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductToCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductToProductConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new BannerGroupConfiguration());
            modelBuilder.ApplyConfiguration(new BannerConfiguration());
            modelBuilder.ApplyConfiguration(new PageConfiguration());
        }

        public class SiteDbContextFactory : IDesignTimeDbContextFactory<SiteDbContext>
        {
            public SiteDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SiteDbContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=3LayerShopDb;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new SiteDbContext(optionsBuilder.Options);
            }
        }
    }
}
