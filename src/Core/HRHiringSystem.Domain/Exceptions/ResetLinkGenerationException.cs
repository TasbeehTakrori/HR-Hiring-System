namespace HRHiringSystem.Domain.Exceptions;
public class ResetLinkGenerationException : Exception
{
    public ResetLinkGenerationException() : base("Failed to generate reset link.")
    {
    }

    public ResetLinkGenerationException(string message) : base(message)
    {
    }
}