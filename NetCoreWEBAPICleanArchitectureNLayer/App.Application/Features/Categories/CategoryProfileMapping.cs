using App.Services.Categories.Dto;
using AutoMapper;
using CleanApp.Application.Features.Categories.Create;
using CleanApp.Application.Features.Categories.Update;
using CleanApp.Domain.Entities;

namespace CleanApp.Application.Features.Categories
{
    public class CategoryProfileMapping : Profile
    {
        public CategoryProfileMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();

            CreateMap<CreateCategoryRequest, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

            CreateMap<UpdateCategoryRequest, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
        }
    }
}
