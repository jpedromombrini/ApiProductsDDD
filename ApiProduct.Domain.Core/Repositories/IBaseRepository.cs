using System.Linq.Expressions;
using ApiProduct.Domain.Entities;

namespace ApiProduct.Domain.Core.Repositories;
public interface IBaseRepository<T> where T : Entity
{
        Task<IEnumerable<T>> GetByexpressionAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByCodigoAsync(int codigo);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);


}
