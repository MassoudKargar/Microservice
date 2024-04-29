namespace Ms.CQRSSamples.Framework;

public abstract class BaseEfUnitOfWork<TDbContext> : IUnitOfWork
    where TDbContext : BaseCommandDbContext
{
    private readonly TDbContext _commandDbContext;

    public BaseEfUnitOfWork(TDbContext commandDbContext)
    {
        _commandDbContext = commandDbContext;
    }
    public void BeginTransaction()
    {
        _commandDbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _commandDbContext.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        _commandDbContext.Database.RollbackTransaction();
    }
}