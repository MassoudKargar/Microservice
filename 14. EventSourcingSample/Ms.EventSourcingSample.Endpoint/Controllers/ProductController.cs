using Microsoft.AspNetCore.Mvc;
using Ms.EventSourcingSample.Domain.Products;
using Ms.EventSourcingSample.Domain.Products.Entities;

namespace Ms.EventSourcingSample.Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    private IProductRepository ProductRepository { get; } = productRepository;

    [HttpPost("/AddNewProduct")]
    public async Task<IActionResult> Post(int id, string name, string description, int price)
    {
        Product product = new(id, name, description, price);
        product.ChangePrice(price -10);
        product.ChangePrice(price +5);
        product.ChangeName(name + "test");
        product.ChangeName(name);
        ProductRepository.Save(product);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var product = productRepository.Get(id);
        return Ok(product);
    }
}