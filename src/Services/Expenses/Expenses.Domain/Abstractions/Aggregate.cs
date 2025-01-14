﻿namespace Expenses.Domain.Abstractions
{
    public class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvents(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequedEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequedEvents;
        }
    }
}
