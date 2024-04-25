using Ms.RepositorySample.Framework;
using Ms.RepositorySamples.Domain.Categories.Entities;

namespace Ms.RepositorySamples.Domain.Categories;

public interface ICategoryRepository : IRepository<Category>
{
    public void Add(Category category);
}