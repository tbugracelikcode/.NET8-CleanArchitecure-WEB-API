using CleanApp.Domain.Entities;

namespace CleanApp.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        public Task <List<Product>> GetTopPriceProductAsync(int count);
    }
}
