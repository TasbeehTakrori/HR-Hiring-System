namespace HRHiringSystem.Domain.Exceptions.Base;
public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(Dictionary<string, string[]> errors) : base("One or more validation errors occurred.")
    {
        Errors = errors;
    }
    public IDictionary<string, string[]> Errors { get; set; }
}