using System.Net;
using App.Services.Products.Create;
using App.Services.Products.Update;
using App.Services.Products.UpdateStock;
using AutoMapper;
using CleanApp.Application.Contracts.Caching;
using CleanApp.Application.Contracts.Persistence;
using CleanApp.Application.Features.Products.Dto;
using CleanApp.Domain.Entities;

namespace CleanApp.Application.Features.Products
{
    public class ProductService(IProductRepository productRepository, IUnitofWork unitofWork, IMapper mapper, ICacheService cacheService) : IProductService
    {

        private const string ProductListCacheKey = "ProductListCacheKey";
        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductAsync(count);

            var productsasDto = mapper.Map<List<ProductDto>>(products);

            return new ServiceResult<List<ProductDto>>()
            {
                Data = productsasDto
            };
        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
        {

            var productListasCached = await cacheService.GetAsync<List<ProductDto>>(ProductListCacheKey);

            if (productListasCached is not null) return ServiceResult<List<ProductDto>>.Success(productListasCached);

            var products = await productRepository.GetAllAsync();

            var productsasDto = mapper.Map<List<ProductDto>>(products);

            await cacheService.AddAsync(ProductListCacheKey, productsasDto, TimeSpan.FromMinutes(1));

            return ServiceResult<List<ProductDto>>.Success(productsasDto);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {

            var products = await productRepository.GetAllPagedAsync(pageNumber, pageSize);

            var productsasDto = mapper.Map<List<ProductDto>>(products);

            return ServiceResult<List<ProductDto>>.Success(productsasDto);
        }

        public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
        {
            var product = await productRepository.GetbyIdAsync(id);

            if (product is null)
            {
                return ServiceResult<ProductDto?>.Fail("Product not found", HttpStatusCode.NotFound);
            }

            var productsasDto = mapper.Map<ProductDto>(product);

            return ServiceResult<ProductDto>.Success(productsasDto)!;
        }

        public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
        {
            var anyProduct = await productRepository.AnyAsync(X => X.Name == request.Name);

            if (anyProduct)
            {
                return ServiceResult<CreateProductResponse>.Fail("The product is already existing.", HttpStatusCode.BadRequest);
            }

            var product = mapper.Map<Product>(request);

            await productRepository.AddAsync(product);

            await unitofWork.SaveChangesAsync();

            return ServiceResult<CreateProductResponse>.SuccessasCreated(new CreateProductResponse(product.Id), $"api/products/{product.Id}");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
        {
            var isProductNameExist = await productRepository.AnyAsync(X => X.Name == request.Name && X.Id != id);

            if (isProductNameExist)
            {
                return ServiceResult.Fail("The product is already existing.", HttpStatusCode.BadRequest);
            }

            var product = mapper.Map<Product>(request);

            product.Id = id;

            productRepository.Update(product);

            await unitofWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request)
        {
            var product = await productRepository.GetbyIdAsync(request.ProductId);

            if (product is null)
            {
                return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
            }

            product.Stock = request.Quantity;

            productRepository.Update(product);

            await unitofWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var product = await productRepository.GetbyIdAsync(id);

            productRepository.Delete(product!);

            await unitofWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
