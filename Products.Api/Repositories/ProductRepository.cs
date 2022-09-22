using Microsoft.EntityFrameworkCore;
using Products.Api.Contracts.Dtos;
using Products.Api.Database.Contexts;
using Products.Api.Entities;
using IMapper = AutoMapper.IMapper;

namespace Products.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductsDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductRepository(ProductsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ProductDto> CreateAsync(ProductDto product)
    {
        Product productToCreate = _mapper.Map<Product>(product);

        Product createdProduct = (await _dbContext.Products.AddAsync(productToCreate)).Entity;
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ProductDto>(createdProduct);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _dbContext.Products.AsNoTracking().ToListAsync();
        return products.Select(p => _mapper.Map<ProductDto>(p));
    }

    public async Task<ProductDto?> GetAsync(Guid id)
    {
        Product? product = await _dbContext.Products.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> UpdateAsync(ProductDto product)
    {
        Product productToUpdate = _mapper.Map<Product>(product);

        Product updatedProduct = (_dbContext.Products.Update(productToUpdate)).Entity;
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ProductDto>(updatedProduct);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var productToDelete = await _dbContext.Products.FindAsync(id);
        var result = _dbContext.Products.Remove(productToDelete!);
        var resultState = result.State;
        await _dbContext.SaveChangesAsync();
        return resultState == EntityState.Deleted;
    }
}