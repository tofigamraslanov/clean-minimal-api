namespace Products.Api.Contracts.Responses;

public class GetAllProductsResponse
{
    public IEnumerable<ProductResponse> Products { get; init; } = Enumerable.Empty<ProductResponse>();
}