using System.Reflection;

namespace Ms.EventSourcingSample.Framework;

public class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
    public int Version { get; private set; }
    public IReadOnlyList<IDomainEvent> Events => _events;
    protected void AddEvent(IDomainEvent @event)
    {
        _events.Add(@event);
    }

    protected void Apply(IDomainEvent @event)
    {
        Mutate(@event);
        AddEvent(@event);
    }

    public AggregateRoot()
    {

    }
    public AggregateRoot(IReadOnlyList<IDomainEvent> domainEvents)
    {
        if (domainEvents == null || domainEvents.Count < 1)
        {
            return;
        }

        foreach (var domainEvent in domainEvents)
        {
            Mutate(domainEvent);
            Version++;
        }

    }
    private void Mutate(IDomainEvent @event)
    {
        //((dynamic)this).On((dynamic)@event);
        var onMethod = this.GetType()
            .GetMethod("On", BindingFlags.Instance | BindingFlags.NonPublic, [@event.GetType()]);
        onMethod.Invoke(this, [@event]);
    }

    public void ClearEvent()
    {
        _events.Clear();
    }

}