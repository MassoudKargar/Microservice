using Microsoft.EntityFrameworkCore;
using Ms.Core.ApplicationServices;
using Ms.Core.Domain;

namespace Ms.Infrastructure.Data.SqlServer;

public class EfPersonRepository(ApplicationDbContext dbContext) : IPersonRepository
{
    private ApplicationDbContext DbContext { get; } = dbContext;

    public void Add(Person person)
    {
        DbContext.People.Add(person);
        DbContext.SaveChanges();
    }

    public Person? Get(int id)
    {
        var person = DbContext.People.Include(c => c.PhoneNumbers).SingleOrDefault(c => c.Id == id);
        return person;
    }

    public void Update(Person person)
    {
        DbContext.SaveChanges();
    }
}