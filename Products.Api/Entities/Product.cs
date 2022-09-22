namespace Products.Api.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } 
    public decimal Price { get; set; }  
    public decimal Rate { get; set; }
}