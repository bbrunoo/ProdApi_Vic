using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Context;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}
    public DbSet<Product> Product { get; set; } = null!;
}