namespace Ms.RepositorySample.Framework;

public class BaseEfRepository<TAggregate, TDbContext> : IRepository<TAggregate>
    where TAggregate : AggregateRoot
    where TDbContext : BaseDbContext
{
    protected readonly TDbContext _dbContext;
    public BaseEfRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public TAggregate Get(long id)
    {
        return _dbContext.Set<TAggregate>().First(c => c.Id == id);
    }
}