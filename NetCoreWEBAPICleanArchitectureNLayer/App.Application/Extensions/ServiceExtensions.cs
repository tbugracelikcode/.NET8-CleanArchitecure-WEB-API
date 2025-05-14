using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CleanApp.Application.Features.Products;
using CleanApp.Application.Features.Categories;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace CleanApp.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICategoryService, CategoryService>();

            //services.AddScoped(typeof(NotFoundFilter<,>));

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddExceptionHandler<CriticalExceptionHandler>();

            //services.AddExceptionHandler<GlobalExceptionHandler>();


            return services;
        }
    }
}
