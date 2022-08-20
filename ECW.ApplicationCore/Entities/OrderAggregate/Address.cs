namespace ECW.ApplicationCore.Entities.OrderAggregate;

public class Address
{
    public string Street { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string? State { get; private set; } 

    public string Country { get; private set; } = string.Empty;

    public string? ZipCode { get; private set; }

    private Address()
    {
    }

    public Address(string street, string city, string state, string country, string zipcode)
    {
        Street = street;
        City = city;
        Country = country;
        ZipCode = zipcode;
        State = state;
    }
}