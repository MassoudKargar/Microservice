namespace Ms.CQRSSamples.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(CategoryServices categoryServices) : ControllerBase
{
    private CategoryServices CategoryServices { get; } = categoryServices;

    [HttpPost]
    public async Task<IActionResult> Post(string categoryName)
    {
        await CategoryServices.CreateCategory(categoryName);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Post(long categoryId, string categoryName)
    {
        await CategoryServices.UpdateCategory(categoryId, categoryName);
        return Ok();
    }
}