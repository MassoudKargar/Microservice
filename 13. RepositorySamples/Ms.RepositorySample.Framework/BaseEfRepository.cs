using Microsoft.EntityFrameworkCore;

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
        var includePath = _dbContext.GetIncludePaths(typeof(TAggregate));
        IQueryable<TAggregate> query = _dbContext.Set<TAggregate>().AsQueryable();
        foreach (var item in includePath)
        {
            query = query.Include(item);
        }
        return query.FirstOrDefault(c => c.Id.Equals(id));
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

}