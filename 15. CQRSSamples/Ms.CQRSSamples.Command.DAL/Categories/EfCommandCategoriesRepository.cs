using Ms.CQRSSamples.Command.DAL;

namespace Ms.CQRSSamples.Command.DAL.Categories;

public class EfCommandCategoriesRepository(RepSampleCommandDbContext commandDbContext) : EfCommandRepository<Category, RepSampleCommandDbContext>(commandDbContext), ICategoryCommandRepository
{
    public void Add(Category category)
    {
        CommandDbContext.Categories.Add(category);
    }
}