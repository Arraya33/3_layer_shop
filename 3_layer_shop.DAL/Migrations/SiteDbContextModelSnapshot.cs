﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3_layer_shop.DAL.EF;

namespace _3_layer_shop.DAL.Migrations
{
    [DbContext(typeof(SiteDbContext))]
    partial class SiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Abstract.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Alias")
                        .IsUnique()
                        .HasFilter("[Alias] IS NOT NULL");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BannerGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BannerGroupId");

                    b.HasIndex("ImageId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.BannerGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BannerGroups");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.CartLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CheckoutId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckoutId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ImageToProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("ImagesToProducts");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Information", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PageId")
                        .IsUnique();

                    b.ToTable("Informations");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountPrice")
                        .HasColumnType("int");

                    b.Property<string>("IntroText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainImageId");

                    b.HasIndex("PageId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PageId")
                        .IsUnique();

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ProductToCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ProductCategoryId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductsToCategories");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ProductToProduct", b =>
                {
                    b.Property<int>("ProductChildId")
                        .HasColumnType("int");

                    b.Property<int>("ProductParentId")
                        .HasColumnType("int");

                    b.HasKey("ProductChildId", "ProductParentId");

                    b.HasIndex("ProductParentId");

                    b.ToTable("ProductsToProducts");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Banner", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.BannerGroup", null)
                        .WithMany("Banners")
                        .HasForeignKey("BannerGroupId");

                    b.HasOne("_3_layer_shop.DAL.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.CartLine", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.Checkout", "Checkout")
                        .WithMany("CartLines")
                        .HasForeignKey("CheckoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_3_layer_shop.DAL.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Checkout", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ImageToProduct", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_layer_shop.DAL.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Information", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.Abstract.Page", "Page")
                        .WithOne()
                        .HasForeignKey("_3_layer_shop.DAL.Entities.Information", "PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.Product", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.Image", "MainImage")
                        .WithMany()
                        .HasForeignKey("MainImageId");

                    b.HasOne("_3_layer_shop.DAL.Entities.Abstract.Page", "Page")
                        .WithOne()
                        .HasForeignKey("_3_layer_shop.DAL.Entities.Product", "PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ProductCategory", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.Abstract.Page", "Page")
                        .WithOne()
                        .HasForeignKey("_3_layer_shop.DAL.Entities.ProductCategory", "PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ProductToCategory", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.ProductCategory", "ProductCategory")
                        .WithMany("ProductToCategories")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_layer_shop.DAL.Entities.Product", "Product")
                        .WithMany("ProductToCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3_layer_shop.DAL.Entities.ProductToProduct", b =>
                {
                    b.HasOne("_3_layer_shop.DAL.Entities.Product", "ProductChild")
                        .WithMany("ProductToProductsParents")
                        .HasForeignKey("ProductChildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_layer_shop.DAL.Entities.Product", "ProductParent")
                        .WithMany("ProductToProductsChilds")
                        .HasForeignKey("ProductParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
