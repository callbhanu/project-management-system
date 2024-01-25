using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsBySubCategoryAsync(int subCategoryId);
        Task<IEnumerable<Product>> GetProductsByCategoryAndSubCategoryAsync(int? categoryId, int? subCategoryId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> GetProductByCodeAsync(string productCode);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync();
        Task<IEnumerable<SubCategory>> GetSubCategoriesByIdAsync(int categoryId);
        Task<Product> AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}
