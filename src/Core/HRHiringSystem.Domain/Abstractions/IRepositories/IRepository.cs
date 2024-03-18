using HRHiringSystem.Domain.Common;
using HRHiringSystem.Domain.Entities;

namespace HRHiringSystem.Domain.Abstractions.IRepositories;
public interface IRepository<TEntity, TModel>
    where TEntity : IBaseEntity
{
    Task<(IEnumerable<TModel>, PaginationMetadata)> GetAllAsync(int pageNumber, int pageSize);
    Task<TModel?> GetByIdAsync(int id);
    Task<TModel> CreateAsync(TModel model);
    void Update(TModel model);
    Task DeleteAsync(int id, bool isHardDelete);
}
