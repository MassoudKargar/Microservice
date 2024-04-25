using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace Ms.RepositorySample.Framework;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {
            
    }
    public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }
  

    public override int SaveChanges()
    {
        HandleBeforSaveChanges();
        return base.SaveChanges();
    }



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleBeforSaveChanges();

        return base.SaveChangesAsync(cancellationToken);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        HandleBeforSaveChanges();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        HandleBeforSaveChanges();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    private void HandleBeforSaveChanges()
    {
        AddToOutBox();
    }

    private void AddToOutBox()
    {
        var entities = ChangeTracker
            .Entries<AggregateRoot>()
            .Where(c => c.State == EntityState.Added || c.State == EntityState.Modified)
            .Select(c => c.Entity).ToList();
        var dateTime = DateTime.Now;
        foreach (var item in entities)
        {
            foreach (var @event in item.Events)
            {
                OutBoxEventItems.Add(new OutBoxEventItem
                {
                    EventId = Guid.NewGuid(),
                    AccuredByUserId = "1",
                    AccuredOn = dateTime,
                    AggregateId = "1",
                    AggregateName = item.GetType().Name,
                    AggregateTypeName = item.GetType().FullName,
                    EventName = @event.GetType().Name,
                    EventTypeName = @event.GetType().FullName,
                    EventPayload = JsonConvert.SerializeObject(@event),
                    IsProcessed = false
                });
            }
        }
    }

}