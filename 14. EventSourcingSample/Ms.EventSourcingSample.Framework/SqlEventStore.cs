using System.Data;
using Newtonsoft.Json;

namespace Ms.EventSourcingSample.Framework;
using Dapper;

using Microsoft.Data.SqlClient;

public class EventStoreItem
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Version { get; set; }
    public string Name { get; set; }
    public string AggregateId { get; set; }
    public string Data { get; set; }
    public string Aggregate { get; set; }
}

public class SqlEventStore : IEventStore
{
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All,
        NullValueHandling = NullValueHandling.Ignore,
    };
    private readonly IDbConnection _db = new SqlConnection(
        "Server=.; Initial Catalog=Microservice_EventSourcing; User Id=masoud; Password=M@$$0ud1001;Encrypt=False;Trust Server Certificate=False;");
    public void Save(string aggregateTypeName, long id,int currentVersion, IReadOnlyList<IDomainEvent> domainEvents)
    {
        string insertCommand = """
                               INSERT INTO [dbo].[EventStore]
                                          ([Id]
                                          ,[CreatedAt]
                                          ,[Version]
                                          ,[Name]
                                          ,[AggregateId]
                                          ,[Data]
                                          ,[Aggregate])
                                    VALUES
                                          (@Id
                                          ,@CreatedAt
                                          ,@Version
                                          ,@Name
                                          ,@AggregateId
                                          ,@Data
                                          ,@Aggregate)
                               """;
        var createdAt = DateTime.Now;
        var itemToSave = domainEvents.Select(s => new
        {
            Id = Guid.NewGuid(),
            CreatedAt = createdAt,
            Version = ++currentVersion,
            Name = s.GetType().Name,
            AggregateId = id,
            Data = JsonConvert.SerializeObject(s, _jsonSerializerSettings),
            Aggregate = aggregateTypeName
        }).ToList();
        _db.Execute(insertCommand, itemToSave);
    }

    public IReadOnlyList<IDomainEvent> Get(string aggregateTypeName, long id)
    {
        string selectCommand = "Select * From [dbo].[EventStore] Where Aggregate=@Aggregate and AggregateId=@AggregateId";
        var parameters = new
        {
            Aggregate = aggregateTypeName,
            AggregateId = id
        };
        List<EventStoreItem> eventStoreItems = _db.Query<EventStoreItem>(selectCommand, parameters).ToList();

        List<IDomainEvent> domainEvents = new();

        foreach (var item in eventStoreItems)
        {
            var myObject = JsonConvert.DeserializeObject(item.Data, _jsonSerializerSettings);
            domainEvents.Add(myObject as IDomainEvent);
        }

        return domainEvents;

    }
}