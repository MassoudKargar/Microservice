namespace Ms.CQRSSamples.Framework;

public class EfCommandRepository<TAggregate, TDbContext>(TDbContext commandDbContext)
    : ICommandRepository<TAggregate>
    where TAggregate : AggregateRoot
    where TDbContext : BaseCommandDbContext
{
    protected readonly TDbContext CommandDbContext = commandDbContext;

    public TAggregate Get(long id)
    {
        var includePath = CommandDbContext.GetIncludePaths(typeof(TAggregate));
        var query = CommandDbContext.Set<TAggregate>().AsQueryable();
        query = includePath.Aggregate(query, (current, item) => current.Include(item));
        return query.First(c => c.Id.Equals(id));
    }

    public void SaveChanges()
    {
        CommandDbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await CommandDbContext.SaveChangesAsync();
    }

}