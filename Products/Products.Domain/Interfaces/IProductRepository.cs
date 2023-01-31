using Products.Domain.Models;

namespace Products.Domain.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId);
    Task<List<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(Guid productId);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(Product product);
}
