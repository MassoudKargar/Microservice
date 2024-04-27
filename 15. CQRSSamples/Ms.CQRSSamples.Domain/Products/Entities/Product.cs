namespace Ms.CQRSSamples.Domain.Products.Entities;

public class Product : AggregateRoot
{
    public Product(string title, string description, int price, int categoryId)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Price = price;
        CategoryId = categoryId;
        AddEvent(new ProductCreated(title, description, price, categoryId));
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Price { get; private set; }
    public int CategoryId { get; private set; }
    private List<Discount> _discounts = new();
    public IReadOnlyList<Discount> Discounts => _discounts;

    public void AddDiscount(string title, int value)
    {
        Discount discount = new(title, value);
        _discounts.Add(discount);
        AddEvent(new DiscountCreated(title, value, Id));
    }
}