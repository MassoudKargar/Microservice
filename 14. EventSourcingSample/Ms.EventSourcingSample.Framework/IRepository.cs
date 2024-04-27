namespace Ms.EventSourcingSample.Framework;

public interface IRepository<TAggregate> where TAggregate : AggregateRoot
{
    TAggregate Get(long id);
    void Save(TAggregate aggregate);
}
