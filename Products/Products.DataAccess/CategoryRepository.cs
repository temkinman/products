
using Microsoft.EntityFrameworkCore;
using Products.Domain.Interfaces;
using Products.Domain.Models;

namespace Products.DataAccess;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;
    public CategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        try
        {
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteCategoryAsync(Category category)
    {
        try
        {
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _appDbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid categoryId)
    {
        return await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        try
        {
            _appDbContext.Categories.Update(category);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
