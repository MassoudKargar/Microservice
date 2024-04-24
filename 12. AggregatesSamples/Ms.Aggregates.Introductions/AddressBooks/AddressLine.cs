using Ms.Aggregates.Framework;

namespace Ms.Aggregates.Introductions.AddressBooks;

public class AddressLine : Entity
{
    public int AddressBookId { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public bool IsDefault { get; set; }
}