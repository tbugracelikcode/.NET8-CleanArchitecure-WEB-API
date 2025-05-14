using CleanApp.API.Filters;
using CleanApp.Application.Features.Categories;
using CleanApp.Application.Features.Categories.Create;
using CleanApp.Application.Features.Categories.Update;
using CleanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await categoryService.GetAllListAsync());

        [HttpGet("{id:int}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(int id) => CreateActionResult(await categoryService.GetCategoryWithProducts(id));

        [HttpGet("products")]
        public async Task<IActionResult> GetCategoryWithProducts() => CreateActionResult(await categoryService.GetCategoryWithProducts());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetbyId(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request) => CreateActionResult(await categoryService.CreateAsync(request));

        [ServiceFilter(typeof(NotFoundFilter<Category, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(id, request));

        [ServiceFilter(typeof(NotFoundFilter<Category, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await categoryService.DeleteAsync(id));
    }
}
