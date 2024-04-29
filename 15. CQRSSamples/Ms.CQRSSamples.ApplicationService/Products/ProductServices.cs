namespace Ms.CQRSSamples.ApplicationService.Products;

public class ProductServices(IProductCommandRepository productCommandRepository)
{
    private readonly IProductCommandRepository _productCommandRepository = productCommandRepository;

    public async Task Handle(CreateProduct dto)
    {
    }

    public async Task Handle(AddDiscount dto)
    {
    }
}