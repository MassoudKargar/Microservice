using Ms.RepositorySample.Framework;
using Ms.RepositorySamples.Domain.Categories;
using Ms.RepositorySamples.Domain.Categories.Entities;

namespace Ms.RepositorySamples.DAL.Categories;

public class EfCategoriesRepository(RepSampleDbContext dbContext) : BaseEfRepository<Category, RepSampleDbContext>(dbContext), ICategoryRepository
{
    public void Add(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }
}