namespace Products.Api.Contracts.Requests;

public class CreateProductRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public decimal Rate { get; set; }
}