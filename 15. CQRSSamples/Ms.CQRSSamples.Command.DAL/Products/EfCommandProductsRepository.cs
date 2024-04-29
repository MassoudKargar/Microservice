using Ms.CQRSSamples.Command.DAL;

namespace Ms.CQRSSamples.Command.DAL.Products;

public class EfCommandProductsRepository(RepSampleCommandDbContext commandDbContext) : EfCommandRepository<Product, RepSampleCommandDbContext>(commandDbContext), IProductCommandRepository
{
    public void Add(Product product)
    {
        CommandDbContext.Products.Add(product);
    }
}