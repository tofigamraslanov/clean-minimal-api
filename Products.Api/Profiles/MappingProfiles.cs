using AutoMapper;
using Products.Api.Contracts.Dtos;
using Products.Api.Contracts.Requests;
using Products.Api.Contracts.Responses;
using Products.Api.Entities;

namespace Products.Api.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateProductRequest, Product>().ReverseMap();

        CreateMap<UpdateProductRequest, Product>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<Product, ProductResponse>().ReverseMap();
    }
}