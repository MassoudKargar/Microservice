namespace Ms.CQRSSamples.ApplicationService.Products.Commands.CreateProducts;

public class CreateProduct : ICommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
}

public class CreateProductHandler(IProductCommandRepository productCommandRepository) : ICommandHandler<CreateProduct>
{
    private IProductCommandRepository ProductCommandRepository { get; set; } = productCommandRepository;

    public async Task Handle(CreateProduct command)
    {

        Product p = new(command.Title, command.Description, command.Price, command.CategoryId);
        ProductCommandRepository.Add(p);
        await ProductCommandRepository.SaveChangesAsync();
    }
}