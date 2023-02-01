using Microsoft.AspNetCore.Mvc;
using Products.Domain.Interfaces;
using Products.Web.Models;

namespace Products.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ResultController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var groupProducts = await _categoryService.GetGroupProductsAsync();

            return View(groupProducts);
        }
    }
}
