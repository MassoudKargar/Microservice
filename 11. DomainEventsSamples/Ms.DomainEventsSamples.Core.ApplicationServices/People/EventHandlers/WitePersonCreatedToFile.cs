using Ms.DomainEventsSample.Core.Domain.People.Events;
using Ms.DomainEventsSample.Framework;
using Newtonsoft.Json;

namespace Ms.DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;

public class WitePersonCreatedToFile : IDomainEventHandler<PersonCreated>
{
    public Task Hanlde(PersonCreated domainEvent)
    {
        string personCreatedstring = JsonConvert.SerializeObject(domainEvent);
        File.WriteAllText("d:\\personCreated.txt", personCreatedstring);
        return Task.CompletedTask;
    }
}