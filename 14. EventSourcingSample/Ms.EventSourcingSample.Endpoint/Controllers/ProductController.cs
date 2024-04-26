using Microsoft.AspNetCore.Mvc;
using Ms.EventSourcingSample.Domain.Products.Entities;

namespace Ms.EventSourcingSample.Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost("/AddNewProduct")]
    public async Task<IActionResult> Post(int id, string name, string description, int price)
    {
        Product product = new(id, name, description, price);

        return Ok(product);
    }
}