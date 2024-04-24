using System.Security.Cryptography.X509Certificates;

namespace Ms.Aggregates.Introductions.AddressBooks;

public class AddressBook
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    private readonly List<AddressLine> _addressLines = new();
    public IReadOnlyList<AddressLine> AddressLines => _addressLines;
    public void AddAddressLine(string address, string city, bool idDefault)
    {
        AddressLine addressLine = new()
        {
            IsDefault = idDefault,
            Address = address,
            City = city
        };
        if (idDefault)
        {
            foreach (var item in _addressLines)
            {
                item.IsDefault = false;
            }
        }
        _addressLines.Add(addressLine);
    }

    public AddressLine? GetDefault() => AddressLines.SingleOrDefault(c => c.IsDefault);
}