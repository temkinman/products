using Microsoft.AspNetCore.Mvc;
using Products.Domain.Interfaces;
using Products.Domain.Models;
using Products.Web.Models;

namespace Products.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public ProductController(
            ILogger<HomeController> logger,
            IProductService productService,
            ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var allCategories = await _categoryService.GetAllCategoriesAsync();

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Product = new(),
                Categories = allCategories
            };

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            bool result = false;

            if(ModelState.IsValid)
            {
                result = await _productService.CreateProductAsync(product);
            }

            return result ? RedirectToAction(nameof(Index)) : RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid productId)
        {
            var productToUpdate = await _productService.GetProductByIdAsync(productId);

            if(productToUpdate == null)
            {
                _logger.LogWarning($"Product with id {productId} was not found");
                return NotFound();
            }

            var allCategories = await _categoryService.GetAllCategoriesAsync();

            ProductViewModel productViewModel = new()
            {
                Product = productToUpdate,
                Categories = allCategories
            };

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                result = await _productService.UpdateProductAsync(product);
            }

            return result ? RedirectToAction(nameof(Index)) : RedirectToAction(nameof(Edit));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var productToDelete = await _productService.GetProductByIdAsync(productId);

            if(productToDelete == null)
            {
                _logger.LogWarning($"Product with id {productId} was not found");
                return NotFound();
            }

            await _productService.DeleteProductAsync(productToDelete);

            return RedirectToAction(nameof(Index));
        }
    }
}
