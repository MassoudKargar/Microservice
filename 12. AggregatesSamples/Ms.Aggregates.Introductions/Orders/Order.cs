namespace Ms.Aggregates.Introductions.Orders;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderLine> OrderLines { get; set; }
    public int GetTotalPrice() => OrderLines.Sum(orderLine => orderLine.Price);
}