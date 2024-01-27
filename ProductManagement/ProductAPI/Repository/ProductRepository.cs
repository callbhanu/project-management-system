using ProductAPI.Data;
using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Repository.Contracts;
using System.Runtime.CompilerServices;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _dbContext.Products
            .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<Product> GetProductByCodeAsync(string productCode)
        {
            return await _dbContext.Products
             .FirstOrDefaultAsync(p => p.ProductCode == productCode);
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products
           .Where(p => p.CategoryId == categoryId)
           .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySubCategoryAsync(int subCategoryId)
        {
            return await _dbContext.Products
            .Where(p => p.SubCategoryId == subCategoryId)
            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndSubCategoryAsync(int? categoryId, int? subCategoryId)
        {
            var query = _dbContext.Products.AsQueryable();

            if (categoryId.HasValue)
            {
                // Filter by category
                query = query.Where(p => p.CategoryId == categoryId);
            }

            if (subCategoryId.HasValue)
            {
                // Filter by subcategory
                query = query.Where(p => p.SubCategoryId == subCategoryId);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
                _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return await GetProductByIdAsync(product.ProductId);
        }

        public async Task UpdateProductAsync(Product product)
        {
                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();
           
        }

        public async Task DeleteProductAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

    }
}
