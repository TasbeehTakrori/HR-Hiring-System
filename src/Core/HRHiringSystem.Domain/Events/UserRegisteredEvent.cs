using HRHiringSystem.Domain.Primitive;

namespace HRHiringSystem.Domain.Events;
public record UserRegisteredEvent(string UserId, string Email) : IDomainEvent;
