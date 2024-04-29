namespace Ms.CQRSSamples.Domain.Products;

public interface IProductCommandRepository : ICommandRepository<Product>
{
    void Add(Product product);
}