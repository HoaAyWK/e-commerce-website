using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Entities;

public class Brand : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;

    public Brand(string name)
    {
        Name = name;
    }
}