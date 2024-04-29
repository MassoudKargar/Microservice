namespace Ms.CQRSSamples.Framework;

public class EfQueryRepository<TDbContext>(TDbContext queryDbContext) : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    private TDbContext QueryDbContext { get; } = queryDbContext;

}