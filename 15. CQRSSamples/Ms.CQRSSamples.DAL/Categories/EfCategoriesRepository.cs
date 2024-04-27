namespace Ms.CQRSSamples.DAL.Categories;

public class EfCategoriesRepository(RepSampleDbContext dbContext) : BaseEfRepository<Category, RepSampleDbContext>(dbContext), ICategoryRepository
{
    public void Add(Category category)
    {
        _dbContext.Categories.Add(category);
    }
}