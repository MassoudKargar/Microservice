﻿namespace Ms.RepositorySample.Framework;

public interface IRepository<TAggregate> where TAggregate : AggregateRoot
{
    TAggregate Get(long id);
    void SaveChanges();
    Task SaveChangesAsync();
}

public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}