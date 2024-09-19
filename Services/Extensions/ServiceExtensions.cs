using Microsoft.Extensions.DependencyInjection;
using Services.Products;

namespace Services.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddService(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();

        return service;
    }
}
