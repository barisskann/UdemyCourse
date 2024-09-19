using Repositories.Products;

namespace Services.Products;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public Task<List<Product>> GetTopPriceProductAsync(int count) => productRepository.GetTopPriceProductAsync(count);
}
