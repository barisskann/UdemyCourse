using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Products;
using System.Reflection;

namespace Services.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddService(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();
        service.AddFluentValidationAutoValidation();
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return service;
    }
}
