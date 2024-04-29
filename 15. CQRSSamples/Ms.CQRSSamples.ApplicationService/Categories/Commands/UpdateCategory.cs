namespace Ms.CQRSSamples.ApplicationService.Categories.Commands;

public class UpdateCategory : ICommand
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}

public class UpdateCategoryHandler(ICategoryCommandRepository categoryCommandRepository) : ICommandHandler<UpdateCategory>
{
    private ICategoryCommandRepository CategoryCommandRepository { get; } = categoryCommandRepository;
    public async Task Handle(UpdateCategory command)
    {
        var category = CategoryCommandRepository.Get(command.CategoryId);
        category.SetName(command.CategoryName);
        await CategoryCommandRepository.SaveChangesAsync();
    }
}