﻿using Ms.DomainEventsSample.Framework;

namespace Ms.DomainEventsSample.Core.Domain.People.Events;

public class LastNameChanged : IDomainEvent
{
    public string LastName { get; }
    public long Id { get; }
    public LastNameChanged(string lastName, long id)
    {
        LastName = lastName;
        Id = id;
    }
}