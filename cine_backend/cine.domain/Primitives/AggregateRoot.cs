using domain.Primitives;

namespace cine.domain;

public abstract class AggregateRoot
{
    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>{};
    public ICollection<DomainEvent> GetDomainEvents() => _domainEvents;
    protected void Raise(DomainEvent domainEvent){
        _domainEvents.Add(domainEvent);
    }
}