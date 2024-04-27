namespace Ms.CQRSSamples.Domain.Products.Entities;

public class Discount : Entity
{
    public Discount(string title, int value)
    {
        Title = title;
        Value = value;
    }

    public string Title { get; private set; }
    public int Value { get; private set; }
}