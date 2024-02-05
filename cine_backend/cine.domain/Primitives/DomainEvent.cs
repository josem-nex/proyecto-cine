using MediatR;
namespace domain.Primitives;
public record DomainEvent (Guid Id) : INotification;