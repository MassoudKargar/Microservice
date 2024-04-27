namespace Ms.CQRSSamples.Domain.Categories;

public interface ICategoryRepository : IRepository<Category>
{
    public void Add(Category category);
}