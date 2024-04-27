using Ms.RepositorySample.Framework;

namespace Ms.RepositorySamples.Domain.Products.Events;

public class DiscountCreated(string title, int value, long productId) : IDomainEvent
{
    public string Title { get; } = title;
    public int Value { get; } = value;
    public long ProductId { get; } = productId;
}