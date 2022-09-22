using Microsoft.AspNetCore.Authorization;
using Products.Api.Contracts.Requests;
using Products.Api.Contracts.Responses;
using Products.Api.Entities;
using Products.Api.Services;
using IMapper = AutoMapper.IMapper;

namespace Products.Api.Endpoints;

[HttpGet("products/{id:guid}"), AllowAnonymous]
public class GetProductEndpoint : Endpoint<GetProductRequest, ProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public GetProductEndpoint(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        Product? product = await _productService.GetAsync(req.Id);

        if (product is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        ProductResponse productResponse = _mapper.Map<ProductResponse>(product);
        await SendOkAsync(productResponse, ct);
    }
}