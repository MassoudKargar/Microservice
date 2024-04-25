using Microsoft.EntityFrameworkCore;
using Ms.RepositorySample.Framework;
using Ms.RepositorySamples.Domain.Categories.Entities;
using Ms.RepositorySamples.Domain.Products.Entities;

namespace Ms.RepositorySamples.DAL;

public class RepSampleDbContext:BaseDbContext
{
    public RepSampleDbContext(DbContextOptions<RepSampleDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}