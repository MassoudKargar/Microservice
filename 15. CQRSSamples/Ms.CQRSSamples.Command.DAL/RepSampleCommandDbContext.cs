namespace Ms.CQRSSamples.Command.DAL;

public class RepSampleCommandDbContext(DbContextOptions<RepSampleCommandDbContext> options)
    : BaseCommandDbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}