namespace Ms.CQRSSamples.ApplicationService.Categories.Commands;

public class UpdateCategory : ICommand
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}

public class UpdateCategoryHandler(ICategoryRepository categoryRepository) : ICommandHandler<UpdateCategory>
{
    private ICategoryRepository CategoryRepository { get; } = categoryRepository;
    public async Task Handle(UpdateCategory command)
    {
        var category = CategoryRepository.Get(command.CategoryId);
        category.SetName(command.CategoryName);
        await CategoryRepository.SaveChangesAsync();
    }
}