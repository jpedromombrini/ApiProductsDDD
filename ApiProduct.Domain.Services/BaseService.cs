using System.Linq.Expressions;
using ApiProduct.Domain.Core.Repositories;
using ApiProduct.Domain.Core.Services;
using ApiProduct.Domain.Entities;

namespace ApiProduct.Domain.Services; 
public abstract class BaseService<T>(
    IBaseRepository<T> repository
) : IBaseService<T> where T : Entity
{
    private readonly IBaseRepository<T> _repository = repository;
    public virtual async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
    }

    public virtual async Task<T?> GetByCodigoAsync(int codigo)
    {
        return await _repository.GetByCodigoAsync(codigo);
    }

    public virtual async Task<IEnumerable<T>> GetByexpressionAsync(Expression<Func<T, bool>> predicate)
    {
        return await _repository.GetByexpressionAsync(predicate);
    }

    public virtual async Task RemoveAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public virtual async Task UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
    }
}
