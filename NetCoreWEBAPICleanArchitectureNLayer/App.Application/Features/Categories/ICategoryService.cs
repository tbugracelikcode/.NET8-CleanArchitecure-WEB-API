using App.Services.Categories.Dto;
using CleanApp.Application.Features.Categories.Create;
using CleanApp.Application.Features.Categories.Update;

namespace CleanApp.Application.Features.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResult<List<CategoryDto>>> GetAllListAsync();

        Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProducts(int categoryId);

        Task<ServiceResult<List<CategoryWithProductsDto>>> GetCategoryWithProducts();

        Task<ServiceResult<CategoryDto?>> GetByIdAsync(int id);

        Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);

        Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request);

        Task<ServiceResult> DeleteAsync(int id);
    }
}
