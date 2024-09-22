using Microsoft.AspNetCore.Mvc;
using Services.Products;

namespace API.Controllers;

public class ProductsController(IProductService productService) : ApiControllerBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await productService.GetAll());
    [HttpGet("{id :int}")]
    public async Task<IActionResult> GetProductById(int id) => CreateActionResult(await productService.GetProductByIdAsnyc(id));
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request) => CreateActionResult(await productService.CreateProductAsync(request));
}
