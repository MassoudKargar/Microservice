using Ms.EventSourcingSample.Domain.Products;
using Ms.EventSourcingSample.Domain.Products.Entities;
using Ms.EventSourcingSample.Framework;

namespace Ms.EventSourcingSample.Dal.Products;

public class ProductRepository(IEventStore eventStore) : IProductRepository
{
    private IEventStore EventStore { get; } = eventStore;

    public Product Get(long id)
    {
        var events = eventStore.Get(nameof(Product), id);
        return new Product(events);
    }

    public void Save(Product aggregate)
    {
        var events = aggregate.Events;
        EventStore.Save(nameof(Product), aggregate.Id, aggregate.Version, events);
        //1. Aggregate
        //2. AggregateId
        //3. Event Data
        //4. EventType
        //5. DateTime

    }
}