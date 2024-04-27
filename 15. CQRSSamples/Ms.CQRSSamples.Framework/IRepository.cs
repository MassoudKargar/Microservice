namespace Ms.CQRSSamples.Framework;

public interface IRepository<TAggregate> where TAggregate : AggregateRoot
{
    TAggregate Get(long id);
    void SaveChanges();
    Task SaveChangesAsync();
}