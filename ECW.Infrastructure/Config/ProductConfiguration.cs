using ECW.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECW.Infrastructure.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.Property(p => p.Id)
            .UseHiLo("product_hilo")
            .IsRequired();

        builder.Property(p => p.Name)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(p => p.Price)
            .IsRequired(true)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Image)
            .IsRequired(false);

        builder.HasOne(p => p.Brand)
            .WithMany()
            .HasForeignKey(p => p.BrandId);

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
    }
}