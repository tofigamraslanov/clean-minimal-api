using Products.Api.Contracts.Dtos;
using Products.Api.Entities;
using Products.Api.Repositories;
using IMapper = AutoMapper.IMapper;

namespace Products.Api.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        //var existingProduct = _repository.GetAsync(product.Id);
        //if (existingProduct is not null)
        //{
        //    var message = $"A product with id {product.Id} already exists";
        //    throw new ValidationException(message, new[]
        //    {
        //        new ValidationFailure(nameof(Product), message)
        //    });
        //}

        var productDto = _mapper.Map<ProductDto>(product);
        var createdProductDto = await _repository.CreateAsync(productDto);
        return _mapper.Map<Product>(createdProductDto);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var productDtos = await _repository.GetAllAsync();
        return productDtos.Select(p => _mapper.Map<Product>(p));
    }

    public async Task<Product?> GetAsync(Guid id)
    {
        var productDto = await _repository.GetAsync(id);
        return _mapper.Map<Product>(productDto);
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        ProductDto productDto = _mapper.Map<ProductDto>(product);
        ProductDto updatedProductDto = await _repository.UpdateAsync(productDto);
        return _mapper.Map<Product>(updatedProductDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}