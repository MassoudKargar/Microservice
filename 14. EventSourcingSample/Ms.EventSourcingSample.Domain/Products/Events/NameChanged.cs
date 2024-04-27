using Ms.EventSourcingSample.Framework;

namespace Ms.EventSourcingSample.Domain.Products.Events;

public class NameChanged(long id,string name) : IDomainEvent
{
    public long Id { get; } = id;
    public string Name { get; } = name;
}