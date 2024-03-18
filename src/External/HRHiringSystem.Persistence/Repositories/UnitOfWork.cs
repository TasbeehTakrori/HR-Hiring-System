using HRHiringSystem.Domain.Abstractions.Repositories;

namespace HRHiringSystem.Persistence.Repositories;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.SaveChangesAsync();
    }
}
