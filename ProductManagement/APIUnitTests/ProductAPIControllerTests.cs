using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAPI.Controllers;
using ProductAPI.Dto;
using ProductAPI.Models;
using ProductAPI.Repository.Contracts;

namespace APIUnitTests
{
    public class ProductAPIControllerTests
    {
        private readonly Mock<IProductRepository> _repository;
        private readonly Mock<IMapper> _mapper;
        public ProductAPIControllerTests()
        {
            _repository = new Mock<IProductRepository>();
            _mapper = new Mock<IMapper>();
        }
       

        [Fact]
        public async Task GetProducts_ReturnsOkResult()
        {
            // Arrange
          
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result =  controller.GetProducts();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }


        [Fact]
        public async Task GetProductById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _repository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = controller.GetProductById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetProductByCategoryAndSubCategory_ReturnsOkResult()
        {
            // Arrange
          
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result =  controller.GetProductByCategoryAndSubCategory(1, 2);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetProductsByCategory_ReturnsOkResult()
        {
            // Arrange
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = controller.GetProductsByCategory(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetProductsBySubCategory_ReturnsOkResult()
        {
            // Arrange
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = controller.GetProductsBySubCategory(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task UpdateProduct_WithValidIdAndProduct_ReturnsNoContentResult()
        {
            // Arrange
            _repository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product());
         
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = await controller.UpdateProduct(1, new ProductCreateDto());

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _repository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);
            
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = await controller.UpdateProduct(1, new ProductCreateDto());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateProduct_WithValidProduct_ReturnsOkResult()
        {
            // Arrange
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = await controller.CreateProduct(new ProductCreateDto());

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CreateProduct_WithNullProduct_ReturnsBadRequestResult()
        {
            // Arrange
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = await controller.CreateProduct(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteProduct_WithValidId_ReturnsNoContentResult()
        {
            // Arrange
            _repository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product());
            
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = await controller.DeleteProduct(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteProduct_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _repository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);
            
            var controller = new ProductAPIController(_repository.Object, _mapper.Object);

            // Act
            var result = await controller.DeleteProduct(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}