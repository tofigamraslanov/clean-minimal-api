namespace Products.Api.Contracts.Responses;

public class ProductResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; } = default!;
    public decimal Price { get; init; }
    public decimal Rate { get; init; }
}