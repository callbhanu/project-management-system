using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Categories table seeding
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Apparel" },
                new Category { CategoryId = 3, Name = "Footwear" }
            );

            // SubCategories table seeding
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { SubCategoryId = 1, Name = "TVs", CategoryId = 1 },
                new SubCategory { SubCategoryId = 2, Name = "Mobiles", CategoryId = 1 },
                new SubCategory { SubCategoryId = 3, Name = "Refrigerators", CategoryId = 1 },

                new SubCategory { SubCategoryId = 4, Name = "Men's Clothing", CategoryId = 2 },
                new SubCategory { SubCategoryId = 5, Name = "Women's Clothing", CategoryId = 2 },

                new SubCategory { SubCategoryId = 6, Name = "Men's Footwear", CategoryId = 3 },
                new SubCategory { SubCategoryId = 7, Name = "Kid's Footwear", CategoryId = 3 }
            );

            // Products table seeding
            modelBuilder.Entity<Product>().HasData(

                 new Product { ProductId = 1, ProductCode = "TV001", Name = "Smart LED TV", Quantity = 20, Price = 599.99m, Description = "High-quality Smart LED TV", ImageUrl = "tv1.jpg", SubCategoryId = 1 },
                 new Product { ProductId = 2, ProductCode = "TV002", Name = "4K Ultra HD TV", Quantity = 15, Price = 899.99m, Description = "4K Ultra HD TV with HDR", ImageUrl = "tv2.jpg", SubCategoryId = 1 },


                 new Product { ProductId = 3, ProductCode = "MOB001", Name = "Android Smartphone", Quantity = 30, Price = 349.99m, Description = "Latest Android smartphone", ImageUrl = "phone1.jpg", SubCategoryId = 2 },
                 new Product { ProductId = 4, ProductCode = "MOB002", Name = "iPhone 13", Quantity = 25, Price = 1099.99m, Description = "Latest iPhone with advanced features", ImageUrl = "phone2.jpg", SubCategoryId = 2 },


                 new Product { ProductId = 5, ProductCode = "REF001", Name = "French Door Refrigerator", Quantity = 10, Price = 1299.99m, Description = "French door refrigerator with water dispenser", ImageUrl = "fridge1.jpg", SubCategoryId = 3 },
                 new Product { ProductId = 6, ProductCode = "REF002", Name = "Top Freezer Refrigerator", Quantity = 12, Price = 699.99m, Description = "Top freezer refrigerator with adjustable shelves", ImageUrl = "fridge2.jpg", SubCategoryId = 3 },


                 new Product { ProductId = 7, ProductCode = "MEN001", Name = "Casual T-Shirt", Quantity = 50, Price = 19.99m, Description = "Comfortable and stylish casual t-shirt for men", ImageUrl = "tshirt1.jpg", SubCategoryId = 4 },
                 new Product { ProductId = 8, ProductCode = "MEN002", Name = "Slim Fit Jeans", Quantity = 35, Price = 39.99m, Description = "Slim fit jeans for a trendy look", ImageUrl = "jeans1.jpg", SubCategoryId = 4 },


                 new Product { ProductId = 9, ProductCode = "WOMEN001", Name = "Maxi Dress", Quantity = 28, Price = 59.99m, Description = "Elegant maxi dress for women", ImageUrl = "dress1.jpg", SubCategoryId = 5 },
                 new Product { ProductId = 10, ProductCode = "WOMEN002", Name = "Blouse", Quantity = 45, Price = 29.99m, Description = "Stylish blouse for a chic look", ImageUrl = "blouse1.jpg", SubCategoryId = 5 },


                 new Product { ProductId = 11, ProductCode = "MFW001", Name = "Sneakers", Quantity = 18, Price = 79.99m, Description = "Comfortable sneakers for men", ImageUrl = "sneakers1.jpg", SubCategoryId = 6 },
                 new Product { ProductId = 12, ProductCode = "MFW002", Name = "Formal Shoes", Quantity = 22, Price = 99.99m, Description = "Classic formal shoes for men", ImageUrl = "formalshoes1.jpg", SubCategoryId = 6 },


                 new Product { ProductId = 13, ProductCode = "KFW001", Name = "Light-up Sneakers", Quantity = 15, Price = 39.99m, Description = "Fun light-up sneakers for kids", ImageUrl = "kidsneakers1.jpg", SubCategoryId = 7 },
                 new Product { ProductId = 14, ProductCode = "KFW002", Name = "Rain Boots", Quantity = 20, Price = 29.99m, Description = "Colorful rain boots for kids", ImageUrl = "rainboots1.jpg", SubCategoryId = 7 }
             );

        }
    }
}
