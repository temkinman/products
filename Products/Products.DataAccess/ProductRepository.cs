
using Microsoft.EntityFrameworkCore;
using Products.Domain.Interfaces;
using Products.Domain.Models;

namespace Products.DataAccess;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        try
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteProductAsync(Product product)
    {
        try
        {
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<Product?> GetProductByIdAsync(Guid productId)
    {
        return await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        return await _appDbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        try
        {
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
