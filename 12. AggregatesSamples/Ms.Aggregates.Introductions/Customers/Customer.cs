using Ms.Aggregates.Framework;

namespace Ms.Aggregates.Introductions.Customers;
public class Customer: AggregateRoot
{
    public string FirtName { get; set; }
    public string LastName { get; set; }
}
