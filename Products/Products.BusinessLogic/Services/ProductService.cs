
using Products.Domain.Interfaces;
using Products.Domain.Models;

namespace Products.BusinessLogic.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        if (product == null)
        {
            return false;
        }

        return await _productRepository.CreateProductAsync(product);
    }

    public async Task<bool> DeleteProductAsync(Product product)
    {
        var deletedProduct = await _productRepository.GetProductByIdAsync(product.Id);

        if (deletedProduct == null)
        {
            return false;
        }

        return await _productRepository.DeleteProductAsync(product);
    }

    public async Task<Product?> GetProductByIdAsync(Guid productId)
    {
        return await _productRepository.GetProductByIdAsync(productId);
    }

    public async Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        return await _productRepository.GetProductsByCategoryIdAsync(categoryId);
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updatedProduct = await _productRepository.GetProductByIdAsync(product.Id);

        if (updatedProduct == null)
        {
            return false;
        }

        return await _productRepository.UpdateProductAsync(product);
    }
}
