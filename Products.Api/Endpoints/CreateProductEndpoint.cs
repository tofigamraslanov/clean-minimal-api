using Microsoft.AspNetCore.Authorization;
using Products.Api.Contracts.Requests;
using Products.Api.Contracts.Responses;
using Products.Api.Entities;
using Products.Api.Services;
using IMapper = AutoMapper.IMapper;

namespace Products.Api.Endpoints;

[HttpPost("products"), AllowAnonymous]
public class CreateProductEndpoint : Endpoint<CreateProductRequest, ProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public CreateProductEndpoint(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async override Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        Product product = _mapper.Map<Product>(req);

        Product createdProduct = await _productService.CreateAsync(product);

        ProductResponse productResponse = _mapper.Map<ProductResponse>(createdProduct);
        await SendCreatedAtAsync<GetProductEndpoint>(new { product.Id }, productResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}