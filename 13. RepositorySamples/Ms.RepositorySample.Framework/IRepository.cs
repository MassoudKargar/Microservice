namespace Ms.RepositorySample.Framework;

public interface IRepository<TAggregate> where TAggregate : AggregateRoot
{
    TAggregate Get(long id);
}

public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}