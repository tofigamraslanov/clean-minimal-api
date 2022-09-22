using Products.Api.Entities;

namespace Products.Api.Services;

public interface IProductService
{
    Task<Product> CreateAsync(Product product);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetAsync(Guid id);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
}