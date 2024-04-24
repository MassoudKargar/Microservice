﻿namespace Ms.Aggregates.Framework;
public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Hanlde(TDomainEvent domainEvent);
}
