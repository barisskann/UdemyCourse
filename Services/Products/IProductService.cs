using Repositories.Products;

namespace Services.Products;

public interface IProductService
{
    public Task<List<Product>> GetTopPriceProductAsync(int count);
    public Task<ServiceResult<Product>> GetProductByIdAsnyc(int id);
    public Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request);
    public Task<ServiceResult> DeleteProductAsync(int id);
    public Task<ServiceResult<List<Product>>> GetAll();
    public Task<ServiceResult<List<Product>>> GetPagedAllListAsync(int pageNumber, int pageSize);
    public Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
}
