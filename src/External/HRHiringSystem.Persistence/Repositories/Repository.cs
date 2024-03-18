using AutoMapper;
using HRHiringSystem.Domain.Abstractions.IRepositories;
using HRHiringSystem.Domain.Common;
using HRHiringSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRHiringSystem.Persistence.Repositories;
public class Repository<TEntity, TModel> : IRepository<TEntity, TModel>
    where TEntity : class, IBaseEntity, ISoftDelete
    where TModel : class
{
    protected readonly DbSet<TEntity> _entities;
    protected readonly IMapper _mapper;

    public Repository(
          ApplicationDbContext dbContext,
          IMapper mapper)
    {
        _entities = dbContext.Set<TEntity>();
        _mapper = mapper;
    }

    public async Task<TModel> CreateAsync(TModel model)
    {
        var entityEntry = await _entities.AddAsync(_mapper.Map<TEntity>(model));
        return _mapper.Map<TModel>(entityEntry.Entity);
    }

    public async Task<(IEnumerable<TModel>, PaginationMetadata)> GetAllAsync(int pageNumber, int pageSize)
    {
        var entities = await _entities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

        var totalItemCount = await _entities.CountAsync();

        var paginationMetadata = new PaginationMetadata(
            totalItemCount, pageSize, pageNumber);

        return (_mapper.Map<IEnumerable<TModel>>(entities), paginationMetadata);
    }

    public async Task<TModel?> GetByIdAsync(int id)
    {
        var entity = await _entities.FindAsync(id);
        if (entity != null)
        {
            _entities.Entry(entity).State = EntityState.Detached;
        }
        return _mapper.Map<TModel>(entity);
    }

    public async Task DeleteAsync(int id, bool isHardDelete)
    {
        TEntity? entity = await _entities.FindAsync(id);
        if (entity == null)
            return;

        if (isHardDelete)
        {
            _entities.Remove(entity);
        }
        else
        {
            entity.IsDeleted = true;
            entity.DeletedOnUtc = DateTime.UtcNow;
            _entities.Entry(entity).State = EntityState.Modified;
        }
    }

    public async Task HardDeleteAsync(int id)
    {
        TEntity? entity = await _entities.FindAsync(id);
        if (entity != null)
        {
            _entities.Remove(entity);
        }
    }

    public void Update(TModel model)
    {
        _entities.Entry(_mapper.Map<TEntity>(model)).State = EntityState.Modified;
    }
}
