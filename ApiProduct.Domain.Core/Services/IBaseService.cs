using System.Linq.Expressions;
using ApiProduct.Domain.Entities;

namespace ApiProduct.Domain.Core.Services;
public interface IBaseService<T> where T : Entity
{
    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task RemoveAsync(T entity);

    Task<IEnumerable<T>> GetByexpressionAsync(Expression<Func<T, bool>> predicate);

    Task<T?> GetByCodigoAsync(int codigo);
}
