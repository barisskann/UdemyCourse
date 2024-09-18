using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Products;

public class ProductRepository(AppDbContext appDbContext) : GenericRepository<Product>(appDbContext), IProductRepository
{
    public Task<List<Product>> GetTopPriceProductAsync(int count) => GetAll().OrderByDescending(x=>x.Price).Take(count).ToListAsync();

}
