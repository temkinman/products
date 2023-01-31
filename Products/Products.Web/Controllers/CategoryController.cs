using Microsoft.AspNetCore.Mvc;
using Products.Domain.Interfaces;
using Products.Domain.Models;

namespace Products.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public CategoryController(
            ILogger<HomeController> logger,
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Category category = new();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                result = await _categoryService.CreateCategoryAsync(category);
            }

            return result ? RedirectToAction(nameof(Index)) : RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid categoryId)
        {
            var productToUpdate = await _categoryService.GetCategoryByIdAsync(categoryId);

            if (productToUpdate == null)
            {
                _logger.LogWarning($"Category with id {categoryId} was not found");
                return NotFound();
            }

            return View(productToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                result = await _categoryService.UpdateCategoryAsync(category);
            }

            return result ? RedirectToAction(nameof(Index)) : RedirectToAction(nameof(Edit));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var categoryToDelete = await _categoryService.GetCategoryByIdAsync(categoryId);

            if (categoryToDelete == null)
            {
                _logger.LogWarning($"Category with id {categoryId} was not found");
                return NotFound();
            }

            await _categoryService.DeleteCategoryAsync(categoryToDelete);

            return RedirectToAction(nameof(Index));
        }
    }
}
