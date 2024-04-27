namespace Ms.RepositorySample.Framework;
public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Hanlde(TDomainEvent domainEvent);
}
