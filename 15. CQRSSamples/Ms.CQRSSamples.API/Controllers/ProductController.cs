namespace Ms.CQRSSamples.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductServices productServices) : ControllerBase
{
    private ProductServices ProductServices { get; } = productServices;

    [HttpPost]
    public async Task<IActionResult> Post(string title, string description, int price, int categoryId)
    {
        await ProductServices.CreateProduct(title, description, price, categoryId);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(long id, string title, int value)
    {
        await ProductServices.UpdateProduct(id, title, value);
        return Ok();
    }
}
