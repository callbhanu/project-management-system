using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dto;
using ProductAPI.Models;
using ProductAPI.Repository.Contracts;

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

        [HttpGet("GetProductById/{id}")]
        public ActionResult<ProductDetailsDto> GetProductById(int id)
        {
            var product = _productRepository.GetProductByIdAsync(id).Result;
            if (product == null)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> UpdateProduct(int productId, [FromForm] ProductCreateDto updatedProduct)
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
            if(updatedProduct.Image != null)
            {
                existingProduct.ImageUrl = await SaveImage(0, updatedProduct.Image);
            }
            
            existingProduct.SubCategoryId = updatedProduct.SubCategoryId;
            existingProduct.CategoryId = updatedProduct.CategoryId;
            await _productRepository.UpdateProductAsync(existingProduct);

            return NoContent(); // HTTP 204 - No content & successful update
        }
        #endregion

        #region POST
        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDto newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest(); // HTTP 400 - Bad request
            }
            if (newProduct.Image != null)
            {
                newProduct.ImageUrl = await SaveImage(0, newProduct.Image);
            }

            var product = _mapper.Map<Product>(newProduct);

            var createdProduct = await _productRepository.AddProductAsync(product);

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

        private async Task<string> SaveImage(int productId, IFormFile image)
        {
            // Save the image to a directory (you might want to customize the path)
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = $"{productId}_{Guid.NewGuid().ToString()}_{image.FileName}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            // Return the relative path to the saved image
            return $"/uploads/{uniqueFileName}";
        }

        #region Commented Code

        //[HttpGet("GetAllCategories")]
        //public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        //{
        //    var categories = _productRepository.GetAllCategoriesAsync();
        //    var categoriesList = categories.Result.Select(c => _mapper.Map<CategoryDto>(c)).ToList();
        //    return Ok(categoriesList);
        //}

        //[HttpGet("GetAllSubCategories")]
        //public ActionResult<IEnumerable<SubCategoryDto>> GetSubCategories()
        //{
        //    var subCategories = _productRepository.GetAllSubCategoriesAsync();
        //    var subCategoriesList = subCategories.Result.Select(c => _mapper.Map<SubCategoryDto>(c)).ToList();
        //    return Ok(subCategoriesList);
        //}

        //[HttpGet("GetSubCategoriesById/{categoryId}")]
        //public ActionResult<IEnumerable<SubCategoryDto>> GetSubCategoriesById(int categoryId)
        //{
        //    var subCategories = _productRepository.GetSubCategoriesByIdAsync(categoryId);
        //    var subCategoriesList = subCategories.Result.Select(c => _mapper.Map<SubCategoryDto>(c)).ToList();
        //    return Ok(subCategoriesList);
        //}
#endregion
    }
}
