using Microsoft.EntityFrameworkCore;

using Ms.DomainEventsSample.Core.Domain;

namespace Ms.DomainEventsSamples.Infra.Dal;

public class SampleContext : DbContext
{
    public SampleContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Person> People { get; set; }
}