namespace Services.Products;

public record UpdateProductRequest(int Id, string name, decimal price, int stock);


