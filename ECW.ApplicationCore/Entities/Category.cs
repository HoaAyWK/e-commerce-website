using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Entities;

public class Category : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;

    public Category(string name)
    {
        Name = name;
    }
}