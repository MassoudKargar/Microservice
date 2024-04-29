using Microsoft.EntityFrameworkCore;

using Ms.CQRSSamples.Domain.Categories.Entities;
using Ms.CQRSSamples.Domain.Products.Entities;
using Ms.CQRSSamples.Framework;

namespace Ms.CQRSSample.Queries.DAL;

public class RepSampleQueryDbContext(DbContextOptions<RepSampleQueryDbContext> options)
    : BaseQueryDbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}