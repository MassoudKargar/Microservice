using Ms.DomainEventsSample.Core.Domain.People.Events;
using Ms.DomainEventsSample.Framework;
using Newtonsoft.Json;

namespace Ms.DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;

public class WitePersonCreatedToConsole : IDomainEventHandler<PersonCreated>
{
    public Task Hanlde(PersonCreated domainEvent)
    {
        string personCreatedstring = JsonConvert.SerializeObject(domainEvent);
        Console.WriteLine(domainEvent);
        return Task.CompletedTask;
    }

}
