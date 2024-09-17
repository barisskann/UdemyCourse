namespace Repositories;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Price { get; set; } = default!;
    public int Stock { get; set; }
}
