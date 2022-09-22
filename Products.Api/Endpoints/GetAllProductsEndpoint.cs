using Microsoft.AspNetCore.Authorization;
using Products.Api.Contracts.Responses;
using Products.Api.Entities;
using Products.Api.Services;
using IMapper = AutoMapper.IMapper;

namespace Products.Api.Endpoints;

[HttpGet("products"), AllowAnonymous]
public class GetAllProductsEndpoint : EndpointWithoutRequest<GetAllProductsResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public GetAllProductsEndpoint(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        IEnumerable<Product> products = await _productService.GetAllAsync();

        GetAllProductsResponse productsResponse = new GetAllProductsResponse()
        {
            Products = products.Select(p => _mapper.Map<ProductResponse>(p))
        };

        await SendOkAsync(productsResponse, ct);
    }
}