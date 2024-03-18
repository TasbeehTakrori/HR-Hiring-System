namespace HRHiringSystem.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(string userName, IEnumerable<string>? roles);
}
