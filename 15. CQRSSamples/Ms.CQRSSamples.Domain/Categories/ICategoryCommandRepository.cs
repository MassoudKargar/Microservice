namespace Ms.CQRSSamples.Domain.Categories;

public interface ICategoryCommandRepository : ICommandRepository<Category>
{
    public void Add(Category category);
}