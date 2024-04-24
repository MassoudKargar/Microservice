
using Ms.DomainEventsSample.Framework;

namespace Ms.DomainEventsSample.Core.Domain;

public class Person : Entity
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public void ChangeFirsName(string firstName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
    }
    public void ChangeLastName(string lastName)
    {
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }
}