using Ms.EventSourcingSample.Framework;

namespace Ms.EventSourcingSample.Domain.Products.Events;

public class ProductCreated(long id, string name, string description, int price) : IDomainEvent
{
    public long Id { get; } = id;
    public string Name { get; } = name;
    public string Description { get; } = description;
    public int Price { get; } = price;
}