using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Products;
using System.Net;

namespace Services.Products;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
{
    public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
    {
        bool x = await productRepository.Where(x => x.Id == 15).AnyAsync();



        await productRepository.AddAsync(new Product { Id = request.Id, Name = request.Name, Price = request.Price, Stock = request.stock });
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(request.Id), HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<Product>>> GetPagedAllListAsync(int pageNumber, int pageSize)
    {
        List<Product> pageResult = await productRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return ServiceResult<List<Product>>.Success(pageResult);
    }

    public async Task<ServiceResult<Product>> GetProductByIdAsnyc(int id)
    {
        Product? result = await productRepository.GetByIdAsync(id);

        return result is null
            ? ServiceResult<Product>.Fail("Product Not Found", HttpStatusCode.NotFound)
            : ServiceResult<Product>.Success(result);
    }

    public async Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request)
    {
        Product? product = await productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
        }

        product.Price = request.price;
        product.Stock = request.stock;
        product.Name = request.name;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();
    }

    public async Task<ServiceResult> DeleteProductAsync(int id)
    {
        Product? product = await productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
        }

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();
    }

    public async Task<ServiceResult<List<Product>>> GetAll()
    {
        return ServiceResult<List<Product>>.Success(await productRepository.GetAll().ToListAsync());
    }

    public Task<List<Product>> GetTopPriceProductAsync(int count)
    {
        return productRepository.GetTopPriceProductAsync(count);
    }
}
