using EventStore.Client;

using Newtonsoft.Json;

namespace Ms.EventSourcingSample.Framework;

public class EsEvenStore : IEventStore
{
    private readonly EventStoreClient _client;
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All,
        NullValueHandling = NullValueHandling.Ignore,
    };

    public EsEvenStore()
    { 
        const string connectionString = "esdb://admin:changeit@127.0.0.1:2113?tls=true&keepAliveTimeout=10000&keepAliveInterval=10000&tlsVerifyCert=false";
        var settings = EventStoreClientSettings.Create(connectionString);
        _client = new EventStoreClient(settings);
    }
    public async void Save(string aggregateTypeName, long id, int currentVersion,
        IReadOnlyList<IDomainEvent> domainEvents)
    {
        IEnumerable<EventData> eventData = domainEvents.Select(c =>
            new EventData(Uuid.NewUuid(), c.GetType().Name, GetSerializedEventData(c)));
        await _client.AppendToStreamAsync(
            StreamId(aggregateTypeName, id),
            StreamState.Any,
            eventData);
    }

    private ReadOnlyMemory<byte> GetSerializedEventData(IDomainEvent @event)
    {
        var jsonEvent = JsonConvert.SerializeObject(@event, _jsonSerializerSettings);
        var byteArray= System.Text.Encoding.UTF8.GetBytes(jsonEvent);
        return byteArray;
    }

    public IReadOnlyList<IDomainEvent> Get(string aggregateTypeName, long id)
    {
        var result = _client.ReadStreamAsync(
            Direction.Forwards,
            StreamId(aggregateTypeName, id),
            StreamPosition.Start);

        var events = result.ToListAsync(CancellationToken.None).Result;
        var domainEvent = events.Select(e => GetDomainEvent(e.Event.Data.ToArray())).ToList();
        return domainEvent;
    }

    private IDomainEvent GetDomainEvent(byte[] data)
    {
        var str = System.Text.Encoding.UTF8.GetString(data);
        var myObject = JsonConvert.DeserializeObject(str, _jsonSerializerSettings);
        var domainEvent = myObject as IDomainEvent;
        return domainEvent;
    }

    private string StreamId(string aggregateTypeName, long id)
    {
        return $"{aggregateTypeName}-{id}";
    }
}