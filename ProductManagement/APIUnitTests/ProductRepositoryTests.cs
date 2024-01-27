using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIUnitTests
{
    public class ProductRepositoryTests
    {
        private DbContextOptions<AppDbContext> CreateDbContextOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

        }

        [Fact]
        public async Task GetProductByIdAsync_WithValidId_ReturnsProduct()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var productId = 1;

            // Add a product to the in-memory database
            var product = new Product { Name = "NewProduct1", CategoryId = 1, SubCategoryId = 1, ProductCode = "AAA", Price = 100, Quantity = 1 };
            context.Products.Add(product);
            context.SaveChanges();

            // Act
            var result = await productRepository.GetProductByIdAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.ProductId);
        }

        [Fact]
        public async Task GetProductByIdAsync_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var productId = 1;

            // Act
            var result = await productRepository.GetProductByIdAsync(productId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetProductByCodeAsync_WithValidCode_ReturnsProduct()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var productCode = "ABC123";

            // Add a product to the in-memory database
            var product = new Product { ProductCode = productCode, Name = "TestProduct" };
            context.Products.Add(product);
            context.SaveChanges();

            // Act
            var result = await productRepository.GetProductByCodeAsync(productCode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productCode, result.ProductCode);
        }

        [Fact]
        public async Task GetProductByCodeAsync_WithInvalidCode_ReturnsNull()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var productCode = "ABC123";

            // Act
            var result = await productRepository.GetProductByCodeAsync(productCode);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetProductsByCategoryAsync_WithValidCategoryId_ReturnsProducts()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var categoryId = 1;

            // Add products to the in-memory database
            var products = new List<Product>
        {
             new Product { Name = "NewProduct1" , CategoryId = categoryId, SubCategoryId =2, ProductCode = "AAA", Price =100, Quantity =1},
            new Product { Name = "NewProduct2" , CategoryId = categoryId, SubCategoryId =2, ProductCode = "AAA", Price =100, Quantity =1},
        };
            context.Products.AddRange(products);
            context.SaveChanges();

            // Act
            var result = await productRepository.GetProductsByCategoryAsync(categoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count());
        }

        [Fact]
        public async Task GetProductsByCategoryAsync_WithInvalidCategoryId_ReturnsEmptyList()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var categoryId = 1;

            // Act
            var result = await productRepository.GetProductsByCategoryAsync(categoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetProductsBySubCategoryAsync_WithValidSubCategoryId_ReturnsProducts()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var subCategoryId = 1;

            // Add products to the in-memory database
            var products = new List<Product>
        {
            new Product { Name = "NewProduct1" , CategoryId = 1, SubCategoryId =subCategoryId, ProductCode = "AAA", Price =100, Quantity =1},
             new Product { Name = "NewProduct1" , CategoryId = 1, SubCategoryId =subCategoryId, ProductCode = "AAA", Price =100, Quantity =1},
        };
            context.Products.AddRange(products);
            context.SaveChanges();

            // Act
            var result = await productRepository.GetProductsBySubCategoryAsync(subCategoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count());
        }

        [Fact]
        public async Task GetProductsBySubCategoryAsync_WithInvalidSubCategoryId_ReturnsEmptyList()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var subCategoryId = 1;

            // Act
            var result = await productRepository.GetProductsBySubCategoryAsync(subCategoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetProductsByCategoryAndSubCategoryAsync_WithValidCategoryAndSubCategory_ReturnsProducts()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var categoryId = 1;
            var subCategoryId = 1;

            // Add products to the in-memory database
            var products = new List<Product>
        {
             new Product { Name = "NewProduct1" , CategoryId = categoryId, SubCategoryId =subCategoryId, ProductCode = "AAA", Price =100, Quantity =1},
             new Product { Name = "NewProduct1" , CategoryId = categoryId, SubCategoryId =subCategoryId, ProductCode = "AAA", Price =100, Quantity =1}
        };
            context.Products.AddRange(products);
            context.SaveChanges();

            // Act
            var result = await productRepository.GetProductsByCategoryAndSubCategoryAsync(categoryId, subCategoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count());
        }

        [Fact]
        public async Task GetProductsByCategoryAndSubCategoryAsync_WithInvalidCategoryAndSubCategory_ReturnsEmptyList()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var categoryId = 1;
            var subCategoryId = 1;

            // Act
            var result = await productRepository.GetProductsByCategoryAndSubCategoryAsync(categoryId, subCategoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAllProductsAsync_ReturnsProducts()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);

            // Add products to the in-memory database
            var products = new List<Product>
        {
           new Product { Name = "NewProduct1" , CategoryId = 1, SubCategoryId =1, ProductCode = "AAA", Price =100, Quantity =1},
            new Product { Name = "NewProduct2", CategoryId = 1, SubCategoryId = 1, ProductCode = "BBB", Price = 100, Quantity = 2 }
        };
            context.Products.AddRange(products);
            context.SaveChanges();

            // Act
            var result = await productRepository.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count());
        }

        [Fact]
        public async Task AddProductAsync_AddsProductToDatabase()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var product = new Product { Name = "NewProduct" , CategoryId = 1, SubCategoryId =1, ProductCode = "AAA", Price =100, Quantity =1};

            // Act
            await productRepository.AddProductAsync(product);

            // Assert
            var result = await context.Products.FindAsync(product.ProductId);
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.Name);
        }

        [Fact]
        public async Task UpdateProductAsync_UpdatesProductInDatabase()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var product = new Product { Name = "OriginalProduct", CategoryId = 1, SubCategoryId = 1, ProductCode = "AAA", Price = 100, Quantity = 1 };

            // Add the original product to the in-memory database
            context.Products.Add(product);
            context.SaveChanges();

            // Act
            product.Name = "UpdatedProduct";
            await productRepository.UpdateProductAsync(product);

            // Assert
            var result = await context.Products.FindAsync(product.ProductId);
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.Name);
        }

        [Fact]
        public async Task DeleteProductAsync_DeletesProductFromDatabase()
        {
            // Arrange
            var options = CreateDbContextOptions();
            using var context = new AppDbContext(options);
            var productRepository = new ProductRepository(context);
            var product = new Product { Name = "ProductToDelete", CategoryId = 1, SubCategoryId = 1, ProductCode = "AAA", Price = 100, Quantity = 1 };

            // Add the product to the in-memory database
            context.Products.Add(product);
            context.SaveChanges();

            // Act
            await productRepository.DeleteProductAsync(product);

            // Assert
            var result = await context.Products.FindAsync(product.ProductId);
            Assert.Null(result);
        }
    }

}
