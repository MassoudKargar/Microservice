namespace Ms.CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;

public class AddDiscount : ICommand
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
}

public class AddDiscountHandler(IProductRepository productRepository) : ICommandHandler<AddDiscount>
{
    private IProductRepository ProductRepository { get; set; } = productRepository;

    public async Task Handle(AddDiscount command)
    {
        var p = ProductRepository.Get(command.Id);
        p.AddDiscount(command.Title, command.Value);
        await ProductRepository.SaveChangesAsync();
    }
}