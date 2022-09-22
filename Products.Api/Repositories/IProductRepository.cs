using Products.Api.Contracts.Dtos;

namespace Products.Api.Repositories;

public interface IProductRepository
{
    Task<ProductDto> CreateAsync(ProductDto product);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetAsync(Guid id);
    Task<ProductDto> UpdateAsync(ProductDto product);
    Task<bool> DeleteAsync(Guid id);
}