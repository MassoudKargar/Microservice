using Microsoft.AspNetCore.Mvc;

using Ms.RepositorySamples.Domain.Categories;
using Ms.RepositorySamples.Domain.Categories.Entities;
using Ms.RepositorySamples.Domain.Common;

namespace Ms.RepositorySample.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(IRepositorySampleDomainUnitOfWork uow, ICategoryRepository categoryRepository) : ControllerBase
{
    private IRepositorySampleDomainUnitOfWork Uow { get; } = uow;
    private ICategoryRepository CategoryRepository { get; } = categoryRepository;

    [HttpPost]
    public async Task<IActionResult> Post(string categoryName)
    {
        var category = new Category(categoryName);
        Uow.BeginTransaction();
        CategoryRepository.Add(category);
        Uow.CommitTransaction();
        return Ok();
    }
}