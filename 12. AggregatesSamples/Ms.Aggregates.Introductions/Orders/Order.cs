using Ms.Aggregates.Framework;

namespace Ms.Aggregates.Introductions.Orders;

public class Order: AggregateRoot
{
    public Order(int addressLineId, DateTime orderDate, List<OrderLine> orderLines)
    {
        if (addressLineId < 1)
        {
            throw new ArgumentException();
        }

        if (!orderLines.Any())
        {
            throw new ArgumentException();
        }

        AddressLineId = addressLineId;
        _orderLines = orderLines;
        OrderDate = orderDate;

    }

    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int AddressLineId { get; set; }
    private List<OrderLine> _orderLines { get; set; }
    public int GetTotalPrice() => _orderLines.Sum(orderLine => orderLine.Price);

    public void ChangeCount(int newCount, int orderLineId)
    {
        var currentPrice = _orderLines.Sum(c => c.GetTotalPrice());

    }
}