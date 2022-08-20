using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Entities;

public class Product : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
   
    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int CategoryId { get; private set; }

    public string Image { get; private set; } = string.Empty;

    public Category? Category { get; private set; }

    public int BrandId { get; private set; }

    public Brand? Brand { get; private set; }

    public Product(
        string name,
        string description,
        decimal price,
        int categoryId,
        int brandId)
    {
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        BrandId = brandId;
    }

    public void UpdateDetails(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public void UpdateBrand(int brandId)
    {
        BrandId = brandId;
    }

    public void UpdateCategory(int categoryId)
    {
        CategoryId = categoryId;
    }

    public void UpdateImage(string image)
    {
        Image = image;
    }
}