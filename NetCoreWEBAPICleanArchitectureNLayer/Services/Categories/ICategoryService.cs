﻿using App.Services.Categories.Create;
using App.Services.Categories.Dto;
using App.Services.Categories.Update;

namespace App.Services.Categories
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
