using ECW.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECW.Infrastructure.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
           .UseHiLo("category_hilo")
           .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}