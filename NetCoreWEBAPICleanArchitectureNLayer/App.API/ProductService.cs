using App.Repositories;
using App.Repositories.Products;

namespace App.API
{
    public class ProductService(IGenericRepository<Product> productRepository)
    {
    }
}
