using AutoMapper;
using ProductAPI.Dto;
using ProductAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Repository.Contracts;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductAPIController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #region GET

        [HttpGet("GetAllProducts")]
        public ActionResult<IEnumerable<ProductDetailsDto>> GetProducts()
        {
           // throw new NotImplementedException();
            var products = _productRepository.GetAllProductsAsync();
            var productDetails = products.Result.Select(p => _mapper.Map<ProductDetailsDto>(p)).ToList();
            return Ok(productDetails);
        }

        [HttpGet("GetAllCategories")]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _productRepository.GetAllCategoriesAsync();
            var categoriesList = categories.Result.Select(c => _mapper.Map<CategoryDto>(c)).ToList();
            return Ok(categoriesList);
        }

        [HttpGet("GetAllSubCategories")]
        public ActionResult<IEnumerable<SubCategoryDto>> GetSubCategories()
        {
            var subCategories = _productRepository.GetAllSubCategoriesAsync();
            var subCategoriesList = subCategories.Result.Select(c => _mapper.Map<SubCategoryDto>(c)).ToList();
            return Ok(subCategoriesList);
        }

        [HttpGet("GetSubCategoriesById/{categoryId}")]
        public ActionResult<IEnumerable<SubCategoryDto>> GetSubCategoriesById(int categoryId)
        {
            var subCategories = _productRepository.GetSubCategoriesByIdAsync(categoryId);
            var subCategoriesList = subCategories.Result.Select(c => _mapper.Map<SubCategoryDto>(c)).ToList();
            return Ok(subCategoriesList);
        }

        [HttpGet("GetProductById/{id}")]
        public ActionResult<ProductDetailsDto> GetProductById(int id)
        {
            var product = _productRepository.GetProductByIdAsync(id).Result;
            var productDetails = _mapper.Map<ProductDetailsDto>(product);
            return Ok(productDetails);

        }


        [HttpGet("GetProductByCategoryAndSubCategory")]
        public ActionResult<ProductDetailsDto> GetProductByCategoryAndSubCategory(int? categoryId, int? subcategoryId)
        {
            var products = _productRepository.GetProductsByCategoryAndSubCategoryAsync(categoryId, subcategoryId);
            var productDetails = products.Result.Select(p => _mapper.Map<ProductDetailsDto>(p)).ToList();
            return Ok(productDetails);

        }

        [HttpGet("GetProductsByCategory/{categoryId}")]
        public ActionResult<IEnumerable<ProductDetailsDto>> GetProductsByCategory(int categoryId)
        {
            var products = _productRepository.GetProductsByCategoryAsync(categoryId);
            var productDetails = products.Result.Select(p => _mapper.Map<ProductDetailsDto>(p)).ToList();
            return Ok(productDetails);
        }

        [HttpGet("GetProductsBySubCategory/{subCategoryId}")]
        public ActionResult<IEnumerable<ProductDetailsDto>> GetProductsBySubCategory(int subCategoryId)
        {
            var products = _productRepository.GetProductsBySubCategoryAsync(subCategoryId);
            var productDetails = products.Result.Select(p => _mapper.Map<ProductDetailsDto>(p)).ToList();
            return Ok(productDetails);
        }

        #endregion

        #region PUT

        [HttpPut("UpdateProduct/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] Product updatedProduct)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productId);

            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Quantity = updatedProduct.Quantity;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.ImageUrl = updatedProduct.ImageUrl;
            existingProduct.SubCategoryId = updatedProduct.SubCategoryId;
            existingProduct.SubCategory.CategoryId = updatedProduct.SubCategory.CategoryId;
            await _productRepository.UpdateProductAsync(existingProduct);

            return NoContent(); // HTTP 204 - No content & successful update
        }
        #endregion

        #region POST
        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest(); // HTTP 400 - Bad request
            }

            var createdProduct = await _productRepository.AddProductAsync(newProduct);

            return Ok();

        }
        #endregion

        #region DELETE

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteProductAsync(existingProduct);
            return NoContent(); // HTTP 204 - No content (successful delete)
        }
        #endregion
    }
}
