using Ms.CQRSSamples.Domain.Products;

namespace Ms.CQRSSamples.ApplicationService.Products;

public class ProductServices(IProductRepository productRepository)
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task CreateProduct(string title, string description, int price, int categoryId)
    {
        Product p = new(title, description, price, categoryId);
        _productRepository.Add(p);
        await _productRepository.SaveChangesAsync();
    }

    public async Task UpdateProduct(long id, string title, int value)
    {
        var p = _productRepository.Get(id);
        p.AddDiscount(title, value);
        await _productRepository.SaveChangesAsync();
    }
}