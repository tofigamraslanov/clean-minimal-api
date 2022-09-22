using Microsoft.EntityFrameworkCore;
using Products.Api.Entities;

namespace Products.Api.Database.Contexts;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
}