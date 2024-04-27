namespace Ms.CQRSSamples.DAL.Products;

public class EfProductsRepository(RepSampleDbContext dbContext) : BaseEfRepository<Product, RepSampleDbContext>(dbContext), IProductRepository
{
    public void Add(Product product)
    {
        _dbContext.Products.Add(product);
    }
}