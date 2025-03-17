using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace FueverProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _categoryService.GetCategoryAsync();
            return Ok(categories);
        }
    }
}