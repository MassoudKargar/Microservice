namespace Ms.CQRSSamples.Framework;

public interface ICommandRepository<out TAggregate> where TAggregate : AggregateRoot
{
    TAggregate Get(long id);
    void SaveChanges();
    Task SaveChangesAsync();
}