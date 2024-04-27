namespace Ms.CQRSSamples.DAL;

public class RepSampleDbContext : BaseDbContext
{
    public RepSampleDbContext(DbContextOptions<RepSampleDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}