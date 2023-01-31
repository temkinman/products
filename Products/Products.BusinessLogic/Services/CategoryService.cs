using Products.Domain.Interfaces;
using Products.Domain.Models;

namespace Products.BusinessLogic.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        if(category == null)
        {
            return false;
        }

        return await _categoryRepository.CreateCategoryAsync(category);
    }

    public async Task<bool> DeleteCategoryAsync(Category category)
    {
        var deletedCategory = _categoryRepository.GetByIdAsync(category.Id);
        if (deletedCategory == null)
        {
            return false;
        }

        return await _categoryRepository.DeleteCategoryAsync(category);
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllCategoriesAsync();
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        var updatedCategory = _categoryRepository.GetByIdAsync(category.Id);
        if (updatedCategory == null)
        {
            return false;
        }

        return await _categoryRepository.UpdateCategoryAsync(category);
    }
}
