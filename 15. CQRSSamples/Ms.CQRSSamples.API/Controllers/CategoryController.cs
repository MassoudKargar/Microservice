namespace Ms.CQRSSamples.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Post([FromServices] CreateCategoryHandler handler, CreateCategory command)
    {
        await handler.Handle(command);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Post([FromServices] UpdateCategoryHandler handler,UpdateCategory command)
    {
        await handler.Handle(command);
        return Ok();
    }
}