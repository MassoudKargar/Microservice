using Ms.Aggregates.Framework;

namespace Ms.RepositorySamples.Domain.Products.Events;

public class ProductCreated(string title, string description, int price, int categoryId)
    : IDomainEvent
{
    public string Title { get; } = title ?? throw new ArgumentNullException(nameof(title));
    public string Description { get; } = description ?? throw new ArgumentNullException(nameof(description));
    public int Price { get; } = price;
    public int CategoryId { get; } = categoryId;
}