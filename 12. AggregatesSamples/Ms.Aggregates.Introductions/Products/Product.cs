using Ms.Aggregates.Framework;

namespace Ms.Aggregates.Introductions.Products;

public class Product : AggregateRoot
{
    public string Name { get; set; }
    public Discount Discount { get; set; }
    public int Price { get; set; }
    public void AddDiscount(int value)
    {
        if (Price - value < 1)
        {
            throw new ArgumentException("Invalid value for discount value");
        }
        Discount.DiscountBalue = value;
    }
}