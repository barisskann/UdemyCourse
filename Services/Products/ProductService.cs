using Microsoft.AspNetCore.Mvc.Formatters;
using Repositories.Products;
using System.Net;

namespace Services.Products;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
    {
        
        await productRepository.AddAsync(new Product { Id = request.Id, Name = request.Name, Price = request.Price, Stock = request.stock });

        return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(request.Id));
    }

    public async Task<ServiceResult<Product>> GetProductByIdAsnyc(int id)
    {
        var result = await productRepository.GetByIdAsync(id);

        if (result is null)
            return ServiceResult<Product>.Fail("Product Not Found", HttpStatusCode.NotFound);

        return ServiceResult<Product>.Success(result);
    }

    public Task<List<Product>> GetTopPriceProductAsync(int count) => productRepository.GetTopPriceProductAsync(count);
}
