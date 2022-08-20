using System.Reflection;
using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Entities.BasketAggregate;
using ECW.ApplicationCore.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace ECW.Infrastructure.Data;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Brand> Brands { get; set; } = null!;

    public DbSet<Category> Category { get; set; } = null!;

    public DbSet<Basket> Baskets { get; set; } = null!;

    public DbSet<BasketItem> BasketItems { get; set; } = null!;

    public DbSet<Order> Order { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;
}