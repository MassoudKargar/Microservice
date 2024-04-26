using Ms.EventSourcingSample.Domain.Products.Events;
using Ms.EventSourcingSample.Framework;

namespace Ms.EventSourcingSample.Domain.Products.Entities;

public class Product : AggregateRoot
{
    public Product(long id, string name, string description, int price)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        AddEvent(new ProductCreated(id, name, description, price));
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public void ChangePrice(int newValue)
    {
        Price = newValue;
        AddEvent(new PriceChanged(Id,newValue));
    }
    public void ChangeName(string newName)
    {
        Name = newName;
        AddEvent(new NameChanged(Id, newName));
    }
}