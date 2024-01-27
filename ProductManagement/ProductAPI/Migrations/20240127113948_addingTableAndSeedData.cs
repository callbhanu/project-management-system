using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "ProductCode", "Quantity", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, 1, "High-quality Smart LED TV", "tv1.jpg", "Smart LED TV", 599.99m, "TV001", 20, 1 },
                    { 2, 1, "4K Ultra HD TV with HDR", "tv2.jpg", "4K Ultra HD TV", 899.99m, "TV002", 15, 1 },
                    { 3, 1, "Latest Android smartphone", "phone1.jpg", "Android Smartphone", 349.99m, "MOB001", 30, 2 },
                    { 4, 1, "Latest iPhone with advanced features", "phone2.jpg", "iPhone 13", 1099.99m, "MOB002", 25, 2 },
                    { 5, 1, "French door refrigerator with water dispenser", "fridge1.jpg", "French Door Refrigerator", 1299.99m, "REF001", 10, 3 },
                    { 6, 1, "Top freezer refrigerator with adjustable shelves", "fridge2.jpg", "Top Freezer Refrigerator", 699.99m, "REF002", 12, 3 },
                    { 7, 2, "Comfortable and stylish casual t-shirt for men", "tshirt1.jpg", "Casual T-Shirt", 19.99m, "MEN001", 50, 4 },
                    { 8, 2, "Slim fit jeans for a trendy look", "jeans1.jpg", "Slim Fit Jeans", 39.99m, "MEN002", 35, 4 },
                    { 9, 2, "Elegant maxi dress for women", "dress1.jpg", "Maxi Dress", 59.99m, "WOMEN001", 28, 5 },
                    { 10, 2, "Stylish blouse for a chic look", "blouse1.jpg", "Blouse", 29.99m, "WOMEN002", 45, 5 },
                    { 11, 3, "Comfortable sneakers for men", "sneakers1.jpg", "Sneakers", 79.99m, "MFW001", 18, 6 },
                    { 12, 3, "Classic formal shoes for men", "formalshoes1.jpg", "Formal Shoes", 99.99m, "MFW002", 22, 6 },
                    { 13, 3, "Fun light-up sneakers for kids", "kidsneakers1.jpg", "Light-up Sneakers", 39.99m, "KFW001", 15, 7 },
                    { 14, 3, "Colorful rain boots for kids", "rainboots1.jpg", "Rain Boots", 29.99m, "KFW002", 20, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
