using Ms.DomainEventsSample.Core.Domain.People.Events;
using Ms.DomainEventsSample.Framework;
using Newtonsoft.Json;

namespace Ms.DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;

public class WiteFirstNameChangedToConsole : IDomainEventHandler<FirstNameChanged>
{
    public Task Hanlde(FirstNameChanged domainEvent)
    {
        string personCreatedstring = JsonConvert.SerializeObject(domainEvent);
        Console.WriteLine(personCreatedstring);
        return Task.CompletedTask;
    }
}