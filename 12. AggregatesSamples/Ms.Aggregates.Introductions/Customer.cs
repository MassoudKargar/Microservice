namespace Ms.Aggregates.Introductions;

public class Customer
{
    public string FirtName { get; set; }
    public string LastName { get; set; }
    public List<Order> Orders { get; set; }

    public int TotalOrderPrice()
    {
        int total = 0;
        foreach (var order in Orders)
        {
            total += order.GetTotalPrice();
        }
        return total;
    }
}

public class Product
{
    public string Name { get; set; }
    public List<OrderLine> OrderLines { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderLine> OrderLines { get; set; }
    public Customer Customer { get; set; }

    public int GetTotalPrice()
    {
        int price = 0;
        foreach (var orderLine in OrderLines)
        {
            price += orderLine.Price;
        }
        return price;
    }
}

 public class OrderLine
{
    public int Price { get; set; }
    public int LineId { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}