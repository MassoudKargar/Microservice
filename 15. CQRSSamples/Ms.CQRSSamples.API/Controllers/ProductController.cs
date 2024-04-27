namespace Ms.CQRSSamples.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    private IProductRepository ProductRepository { get; } = productRepository;

    [HttpPost]
    public async Task<IActionResult> Post(string title, string description, int price, int categoryId)
    {
        Product p = new(title, description, price, categoryId);
        ProductRepository.Add(p);
        productRepository.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(long id, string title, int value)
    {
        var p = ProductRepository.Get(id);
        p.AddDiscount(title, value);
        ProductRepository.SaveChanges();
        return Ok();
    }
}
