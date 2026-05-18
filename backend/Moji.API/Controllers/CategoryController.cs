using Microsoft.AspNetCore.Mvc;
using Moji.Application.DTOS.Category;
using Moji.Application.Interfaces;

namespace Moji.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
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
            var result=await _categoryService.GetCategoryAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm]CreateCategoryRequest request)
        {
            await _categoryService.CreateCategoryAsync(request);
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id,UpdateCategoryRequest request)
        {
            await _categoryService.UpdateCategoryAsync(id,request);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
