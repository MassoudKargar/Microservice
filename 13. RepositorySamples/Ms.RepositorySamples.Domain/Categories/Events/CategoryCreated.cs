using Ms.Aggregates.Framework;

namespace Ms.RepositorySamples.Domain.Categories.Events;

public class CategoryCreated : IDomainEvent
{
    public CategoryCreated(string title)
    {
        Title = title;
    }

    public string Title { get; }

}