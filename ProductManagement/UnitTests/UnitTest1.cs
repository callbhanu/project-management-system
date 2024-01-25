using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAPI.Controllers;
using ProductAPI.Dto;
using ProductAPI.Models;
using ProductAPI.Repository.Contracts;
using Xunit;

namespace UnitTests
{
    public class ProductAPIControllerTests
    {
        [Fact]
        public async Task GetProducts_ReturnsOkResultWithData()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ProductAPIController(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetAllProductsAsync())
                .ReturnsAsync(new List<Product> { new Product() }); // Provide sample products

            // Act
            var result =  controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsType<List<ProductDetailsDto>>(okResult.Value);
            Assert.Single(products); // Ensure that there is at least one product
        }

        [Fact]
        public async Task GetCategories_ReturnsOkResultWithData()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ProductAPIController(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetAllCategoriesAsync())
                .ReturnsAsync(new List<Category> { new Category() }); // Provide sample categories

            // Act
            var result =  controller.GetCategories();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var categories = Assert.IsType<List<CategoryDto>>(okResult.Value);
            Assert.Single(categories); // Ensure that there is at least one category
        }

        [Fact]
        public async Task GetSubCategories_ReturnsOkResultWithData()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ProductAPIController(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetAllSubCategoriesAsync())
                .ReturnsAsync(new List<SubCategory> { new SubCategory() }); // Provide sample subcategories

            // Act
            var result =  controller.GetSubCategories();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var subCategories = Assert.IsType<List<SubCategoryDto>>(okResult.Value);
            Assert.Single(subCategories); // Ensure that there is at least one subcategory
        }


        [Fact]
        public async Task UpdateProduct_ExistingProduct_ReturnsNoContent()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ProductAPIController(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Product()); // Provide a sample existing product

            // Act
            var result = await controller.UpdateProduct(1, new Product());

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_NonExistingProduct_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ProductAPIController(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Product)null); // Simulate non-existing product

            // Act
            var result = await controller.UpdateProduct(1, new Product());

            // Assert
            Xunit.Assert.IsType<NotFoundResult>(result);
        }
    }
}