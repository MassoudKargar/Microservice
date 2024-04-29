namespace Ms.CQRSSamples.ApplicationService.Products.Commands.CreateProducts;

public class CreateProduct : ICommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
}

public class CreateProductHandler(IProductRepository productRepository) : ICommandHandler<CreateProduct>
{
    private IProductRepository ProductRepository { get; set; } = productRepository;

    public async Task Handle(CreateProduct command)
    {

        Product p = new(command.Title, command.Description, command.Price, command.CategoryId);
        ProductRepository.Add(p);
        await ProductRepository.SaveChangesAsync();
    }
}