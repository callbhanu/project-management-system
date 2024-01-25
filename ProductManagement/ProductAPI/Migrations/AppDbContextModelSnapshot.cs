﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAPI.Data;

#nullable disable

namespace ProductAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Apparel"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Footwear"
                        });
                });

            modelBuilder.Entity("ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "High-quality Smart LED TV",
                            ImageUrl = "tv1.jpg",
                            Name = "Smart LED TV",
                            Price = 599.99m,
                            ProductCode = "TV001",
                            Quantity = 20,
                            SubCategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "4K Ultra HD TV with HDR",
                            ImageUrl = "tv2.jpg",
                            Name = "4K Ultra HD TV",
                            Price = 899.99m,
                            ProductCode = "TV002",
                            Quantity = 15,
                            SubCategoryId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Latest Android smartphone",
                            ImageUrl = "phone1.jpg",
                            Name = "Android Smartphone",
                            Price = 349.99m,
                            ProductCode = "MOB001",
                            Quantity = 30,
                            SubCategoryId = 2
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Latest iPhone with advanced features",
                            ImageUrl = "phone2.jpg",
                            Name = "iPhone 13",
                            Price = 1099.99m,
                            ProductCode = "MOB002",
                            Quantity = 25,
                            SubCategoryId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "French door refrigerator with water dispenser",
                            ImageUrl = "fridge1.jpg",
                            Name = "French Door Refrigerator",
                            Price = 1299.99m,
                            ProductCode = "REF001",
                            Quantity = 10,
                            SubCategoryId = 3
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "Top freezer refrigerator with adjustable shelves",
                            ImageUrl = "fridge2.jpg",
                            Name = "Top Freezer Refrigerator",
                            Price = 699.99m,
                            ProductCode = "REF002",
                            Quantity = 12,
                            SubCategoryId = 3
                        },
                        new
                        {
                            ProductId = 7,
                            Description = "Comfortable and stylish casual t-shirt for men",
                            ImageUrl = "tshirt1.jpg",
                            Name = "Casual T-Shirt",
                            Price = 19.99m,
                            ProductCode = "MEN001",
                            Quantity = 50,
                            SubCategoryId = 4
                        },
                        new
                        {
                            ProductId = 8,
                            Description = "Slim fit jeans for a trendy look",
                            ImageUrl = "jeans1.jpg",
                            Name = "Slim Fit Jeans",
                            Price = 39.99m,
                            ProductCode = "MEN002",
                            Quantity = 35,
                            SubCategoryId = 4
                        },
                        new
                        {
                            ProductId = 9,
                            Description = "Elegant maxi dress for women",
                            ImageUrl = "dress1.jpg",
                            Name = "Maxi Dress",
                            Price = 59.99m,
                            ProductCode = "WOMEN001",
                            Quantity = 28,
                            SubCategoryId = 5
                        },
                        new
                        {
                            ProductId = 10,
                            Description = "Stylish blouse for a chic look",
                            ImageUrl = "blouse1.jpg",
                            Name = "Blouse",
                            Price = 29.99m,
                            ProductCode = "WOMEN002",
                            Quantity = 45,
                            SubCategoryId = 5
                        },
                        new
                        {
                            ProductId = 11,
                            Description = "Comfortable sneakers for men",
                            ImageUrl = "sneakers1.jpg",
                            Name = "Sneakers",
                            Price = 79.99m,
                            ProductCode = "MFW001",
                            Quantity = 18,
                            SubCategoryId = 6
                        },
                        new
                        {
                            ProductId = 12,
                            Description = "Classic formal shoes for men",
                            ImageUrl = "formalshoes1.jpg",
                            Name = "Formal Shoes",
                            Price = 99.99m,
                            ProductCode = "MFW002",
                            Quantity = 22,
                            SubCategoryId = 6
                        },
                        new
                        {
                            ProductId = 13,
                            Description = "Fun light-up sneakers for kids",
                            ImageUrl = "kidsneakers1.jpg",
                            Name = "Light-up Sneakers",
                            Price = 39.99m,
                            ProductCode = "KFW001",
                            Quantity = 15,
                            SubCategoryId = 7
                        },
                        new
                        {
                            ProductId = 14,
                            Description = "Colorful rain boots for kids",
                            ImageUrl = "rainboots1.jpg",
                            Name = "Rain Boots",
                            Price = 29.99m,
                            ProductCode = "KFW002",
                            Quantity = 20,
                            SubCategoryId = 7
                        });
                });

            modelBuilder.Entity("ProductAPI.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            SubCategoryId = 1,
                            CategoryId = 1,
                            Name = "TVs"
                        },
                        new
                        {
                            SubCategoryId = 2,
                            CategoryId = 1,
                            Name = "Mobiles"
                        },
                        new
                        {
                            SubCategoryId = 3,
                            CategoryId = 1,
                            Name = "Refrigerators"
                        },
                        new
                        {
                            SubCategoryId = 4,
                            CategoryId = 2,
                            Name = "Men's Clothing"
                        },
                        new
                        {
                            SubCategoryId = 5,
                            CategoryId = 2,
                            Name = "Women's Clothing"
                        },
                        new
                        {
                            SubCategoryId = 6,
                            CategoryId = 3,
                            Name = "Men's Footwear"
                        },
                        new
                        {
                            SubCategoryId = 7,
                            CategoryId = 3,
                            Name = "Kid's Footwear"
                        });
                });

            modelBuilder.Entity("ProductAPI.Models.Product", b =>
                {
                    b.HasOne("ProductAPI.Models.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("ProductAPI.Models.SubCategory", b =>
                {
                    b.HasOne("ProductAPI.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductAPI.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("ProductAPI.Models.SubCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
