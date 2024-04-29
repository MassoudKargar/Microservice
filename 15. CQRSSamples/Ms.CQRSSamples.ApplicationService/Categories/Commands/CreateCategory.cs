namespace Ms.CQRSSamples.ApplicationService.Categories.Commands;

public class CreateCategory : ICommand
{
    public string CategoryName { get; set; } = string.Empty;
}

public class CreateCategoryHandler(ICategoryRepository  categoryRepository) : ICommandHandler<CreateCategory>
{
    private ICategoryRepository CategoryRepository { get; } = categoryRepository;
    public async Task Handle(CreateCategory command)
    {
        var category = new Category(command.CategoryName);
        CategoryRepository.Add(category);
        await CategoryRepository.SaveChangesAsync();
    }
}