using Microsoft.EntityFrameworkCore;

namespace Repositories.Products;

public class ProductRepository(AppDbContext appDbContext) : GenericRepository<Product>(appDbContext), IProductRepository
{
    public Task<List<Product>> GetTopPriceProductAsync(int count) => GetAll().OrderByDescending(x => x.Price).Take(count).ToListAsync();
}
