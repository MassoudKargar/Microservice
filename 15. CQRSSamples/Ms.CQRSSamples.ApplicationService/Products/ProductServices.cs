namespace Ms.CQRSSamples.ApplicationService.Products;

public class ProductServices(IProductRepository productRepository)
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(CreateProduct dto)
    {
    }

    public async Task Handle(AddDiscount dto)
    {
    }
}