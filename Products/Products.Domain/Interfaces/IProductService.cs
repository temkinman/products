using Products.Domain.Models;

namespace Products.Domain.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId);
    Task<Product?> GetProductByIdAsync(Guid productId);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(Product product);
}
