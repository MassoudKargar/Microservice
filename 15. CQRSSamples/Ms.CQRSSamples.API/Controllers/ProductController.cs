namespace Ms.CQRSSamples.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Post([FromServices] CreateProductHandler handler,CreateProduct command)
    {
        await handler.Handle(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(AddDiscountHandler handler,AddDiscount command)
    {
        await handler.Handle(command);
        return Ok();
    }
}
