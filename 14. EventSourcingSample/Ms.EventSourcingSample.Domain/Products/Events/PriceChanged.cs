using Ms.EventSourcingSample.Framework;

namespace Ms.EventSourcingSample.Domain.Products.Events;

public class PriceChanged(long id,int price) : IDomainEvent
{
    public long Id { get; } = id;
    public int Price { get; } = price;
}