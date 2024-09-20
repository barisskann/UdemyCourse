using Repositories.Products;

namespace Services.Products;

public interface IProductService
{
    public Task<List<Product>> GetTopPriceProductAsync(int count);
    public Task<ServiceResult<Product>> GetProductByIdAsnyc(int id);
    public Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
}
