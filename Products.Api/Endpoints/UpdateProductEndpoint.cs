using Microsoft.AspNetCore.Authorization;
using Products.Api.Contracts.Requests;
using Products.Api.Contracts.Responses;
using Products.Api.Entities;
using Products.Api.Services;
using IMapper = AutoMapper.IMapper;

namespace Products.Api.Endpoints;

[HttpPut("products/{id:guid}"), AllowAnonymous]
public class UpdateProductEndpoint : Endpoint<UpdateProductRequest, ProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public UpdateProductEndpoint(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public override async Task HandleAsync(UpdateProductRequest req, CancellationToken ct)
    {
        var existingProduct = await _productService.GetAsync(req.Id);
        if (existingProduct is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        Product product = _mapper.Map<Product>(req);
        Product updatedProduct = await _productService.UpdateAsync(product);

        ProductResponse productResponse = _mapper.Map<ProductResponse>(updatedProduct);
        await SendOkAsync(productResponse, ct);
    }
}
