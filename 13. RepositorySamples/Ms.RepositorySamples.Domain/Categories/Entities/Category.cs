using Ms.Aggregates.Framework;

namespace Ms.RepositorySamples.Domain.Categories.Entities;

public class Category : AggregateRoot
{
    public Category(string title)
    {
        Title = title;
        AddEvent(new CategoryCreated(title));
    }

    public string Title { get; private set; }

}