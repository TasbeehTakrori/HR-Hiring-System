using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Domain.Exceptions;

public class UserRegistrationFailedException : Exception
{
    public IEnumerable<IdentityError> Errors { get; }

    public UserRegistrationFailedException(IEnumerable<IdentityError> errors)
        : base($"Failed to register user. Errors: {string.Join(", ", errors.Select(e => e.Description))}")
    {
        Errors = errors;
    }
}

