using Ms.EventSourcingSample.Domain.Products;
using Ms.EventSourcingSample.Domain.Products.Entities;

namespace Ms.EventSourcingSample.Dal.Products;

public class ProductRepository : IProductRepository
{
    public Product Get(long id)
    {
        throw new NotImplementedException();
    }

    public void Save(Product aggregate)
    {
        var events = aggregate.Events;
        //1. Aggregate
        //2. AggregateId
        //3. Event Data
        //4. EventType
        //5. DateTime

    }
}