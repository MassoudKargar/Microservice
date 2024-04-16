using Microsoft.EntityFrameworkCore;
using Ms.Core.Domain;

namespace Ms.Infrastructure.Data.SqlServer;

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=Microservice; User Id=masoud; Password=M@$$0ud1001;Encrypt=False;Trust Server Certificate=False;");
    }
}