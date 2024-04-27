using Ms.RepositorySample.Framework;
using Ms.RepositorySamples.Domain.Products.Entities;

namespace Ms.RepositorySamples.Domain.Products;

public interface IProductRepository : IRepository<Product>
{
    void Add(Product product);
}