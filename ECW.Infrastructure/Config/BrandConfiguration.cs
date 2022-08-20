using ECW.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECW.Infrastructure.Config;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
           .UseHiLo("brand_hilo")
           .IsRequired();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}