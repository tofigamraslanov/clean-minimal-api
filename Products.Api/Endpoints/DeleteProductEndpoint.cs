using Microsoft.AspNetCore.Authorization;
using Products.Api.Contracts.Requests;
using Products.Api.Services;

namespace Products.Api.Endpoints;

[HttpDelete("products/{id:guid}"), AllowAnonymous]
public class DeleteProductEndpoint : Endpoint<DeleteProductRequest>
{
    private readonly IProductService _productService;

    public DeleteProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(DeleteProductRequest req, CancellationToken ct)
    {
        var deletedProduct = await _productService.DeleteAsync(req.Id);
        if (!deletedProduct)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
