using Microsoft.AspNetCore.Mvc;

using Ms.RepositorySamples.Domain.Categories;
using Ms.RepositorySamples.Domain.Categories.Entities;
using Ms.RepositorySamples.Domain.Common;

namespace Ms.RepositorySample.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    private ICategoryRepository CategoryRepository { get; } = categoryRepository;

    [HttpPost]
    public async Task<IActionResult> Post(string categoryName)
    {
        var category = new Category(categoryName);
        CategoryRepository.Add(category);
        await CategoryRepository.SaveChangesAsync();
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Post(long categoryId,string categoryName)
    {
        var category = CategoryRepository.Get(categoryId);
        category.SetName(categoryName);
        await CategoryRepository.SaveChangesAsync();
        return Ok();
    }
}