namespace Ms.CQRSSamples.Domain.Categories.Events;

public class NameChanged : IDomainEvent
{
    public NameChanged(long id, string title)
    {
        Title = title;
        Id = id;
    }
    public long Id { get; }
    public string Title { get; }

}