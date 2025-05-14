using System.Net;
using App.Services.Categories.Dto;
using AutoMapper;
using CleanApp.Application.Contracts.Persistence;
using CleanApp.Application.Features.Categories.Create;
using CleanApp.Application.Features.Categories.Update;
using CleanApp.Domain.Entities;

namespace CleanApp.Application.Features.Categories
{
    public class CategoryService(ICategoryRepository categoryRepository, IUnitofWork unitofWork, IMapper mapper) : ICategoryService
    {
        public async Task<ServiceResult<List<CategoryDto>>> GetAllListAsync()
        {
            var categories = await categoryRepository.GetAllAsync();

            var categorysasDto = mapper.Map<List<CategoryDto>>(categories);

            return ServiceResult<List<CategoryDto>>.Success(categorysasDto);
        }

        public async Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProducts(int categoryId)
        {
            var category = await categoryRepository.GetCategoryWithProductsAsync(categoryId);

            if(category is null)
            {
                return ServiceResult<CategoryWithProductsDto>.Fail("Category ont found.", HttpStatusCode.NotFound);
            }

            var categoryasDto = mapper.Map<CategoryWithProductsDto>(category);

            return ServiceResult<CategoryWithProductsDto>.Success(categoryasDto);
        }

        public async Task<ServiceResult<List<CategoryWithProductsDto>>> GetCategoryWithProducts()
        {
            var category = await categoryRepository.GetCategoryByProductsAsync();

            var categoryasDto = mapper.Map<List<CategoryWithProductsDto>>(category);

            return ServiceResult< List<CategoryWithProductsDto>>.Success(categoryasDto);
        }

        public async Task<ServiceResult<CategoryDto?>> GetByIdAsync(int id)
        {
            var category = await categoryRepository.GetbyIdAsync(id);

            if (category is null)
            {
                return ServiceResult<CategoryDto?>.Fail("Category not found", HttpStatusCode.NotFound);
            }

            var categorysasDto = mapper.Map<CategoryDto>(category);

            return ServiceResult<CategoryDto>.Success(categorysasDto)!;
        }

        public async Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request)
        {
            var anyCategories = await categoryRepository.AnyAsync(x => x.Name == request.Name);

            if(anyCategories)
            {
                return ServiceResult<int>.Fail("The category is already existing.", HttpStatusCode.BadRequest);
            }

            var newCategory = mapper.Map<Category>(request);

            await categoryRepository.AddAsync(newCategory);

            await unitofWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessasCreated(newCategory.Id, $"api/categories/{newCategory.Id}");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request)
        {

            var isCategoryNameExist = await categoryRepository.AnyAsync(X => X.Name == request.Name && X.Id != id);

            if (isCategoryNameExist)
            {
                return ServiceResult.Fail("The category is already existing.", HttpStatusCode.BadRequest);
            }

            var category = mapper.Map<Category>(request);

            category.Id = id;

            categoryRepository.Update(category);

            await unitofWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var category = await categoryRepository.GetbyIdAsync(id);

            categoryRepository.Delete(category!);

            await unitofWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
