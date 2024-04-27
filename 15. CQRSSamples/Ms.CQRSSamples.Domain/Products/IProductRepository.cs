namespace Ms.CQRSSamples.Domain.Products;

public interface IProductRepository : IRepository<Product>
{
    void Add(Product product);
}