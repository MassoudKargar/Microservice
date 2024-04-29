using Ms.CQRSSamples.Domain.Categories;
using Ms.CQRSSamples.Domain.Categories.Entities;

namespace Ms.CQRSSamples.ApplicationService.Categories;

public class CategoryServices(ICategoryRepository categoryRepository)
{
    private ICategoryRepository CategoryRepository { get; } = categoryRepository;

    public async Task CreateCategory(string categoryName)
    {
        var category = new Category(categoryName);
        CategoryRepository.Add(category);
        await CategoryRepository.SaveChangesAsync();

    }

    public async Task UpdateCategory(long categoryId, string categoryName)
    {
        var category = CategoryRepository.Get(categoryId);
        category.SetName(categoryName);
        await CategoryRepository.SaveChangesAsync();

    }

}