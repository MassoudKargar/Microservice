namespace Ms.CQRSSamples.ApplicationService.Categories.Commands;

public class CreateCategory : ICommand
{
    public string CategoryName { get; set; } = string.Empty;
}

public class CreateCategoryHandler(ICategoryCommandRepository  categoryCommandRepository) : ICommandHandler<CreateCategory>
{
    private ICategoryCommandRepository CategoryCommandRepository { get; } = categoryCommandRepository;
    public async Task Handle(CreateCategory command)
    {
        var category = new Category(command.CategoryName);
        CategoryCommandRepository.Add(category);
        await CategoryCommandRepository.SaveChangesAsync();
    }
}