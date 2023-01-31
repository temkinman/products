using Microsoft.AspNetCore.Mvc;
using Products.Domain.Interfaces;
using Products.Web.Models;

namespace Products.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ResultController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();

            //var joinResult = products.Join(
            //        categories,
            //        product => product.CategoryId,
            //        category => category.Id,
            //        (product, category) => new CategoryProductViewModel(category.Name, product.Name)
            //    );

            var joinResult = categories.GroupJoin(products,
                    category => category.Id,
                    product => product.CategoryId,
                    (category, productsGroup) => new GroupProductViewModel{
                        Category = category.Name,
                        Products = productsGroup
                    }
                );

            return View("GroupProducts", joinResult);
        }
    }
}
