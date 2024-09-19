using Repositories.Products;

namespace Services.Products;

public interface IProductService
{
    public Task<List<Product>> GetTopPriceProductAsync(int count);
}
