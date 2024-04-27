using Ms.EventSourcingSample.Domain.Products.Entities;
using Ms.EventSourcingSample.Framework;

namespace Ms.EventSourcingSample.Domain.Products;

public interface IProductRepository : IRepository<Product>
{
}