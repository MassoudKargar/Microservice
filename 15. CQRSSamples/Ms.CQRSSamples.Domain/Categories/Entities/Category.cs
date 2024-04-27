namespace Ms.CQRSSamples.Domain.Categories.Entities;

public class Category : AggregateRoot
{
    public Category(string title)
    {
        Title = title;
        AddEvent(new CategoryCreated(title));
    }

    public string Title { get; private set; }

    public void SetName(string title)
    {
        Title = title;
        AddEvent(new NameChanged(Id, title));
    }
}