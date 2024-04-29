namespace Ms.CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;

public class AddDiscount : ICommand
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
}

public class AddDiscountHandler(IProductCommandRepository productCommandRepository) : ICommandHandler<AddDiscount>
{
    private IProductCommandRepository ProductCommandRepository { get; set; } = productCommandRepository;

    public async Task Handle(AddDiscount command)
    {
        var p = ProductCommandRepository.Get(command.Id);
        p.AddDiscount(command.Title, command.Value);
        await ProductCommandRepository.SaveChangesAsync();
    }
}