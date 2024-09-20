namespace Services.Products;

public record CreateProductRequest(int Id, string Name, decimal Price, int stock);

