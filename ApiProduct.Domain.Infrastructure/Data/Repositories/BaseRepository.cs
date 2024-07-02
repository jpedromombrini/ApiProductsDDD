using System.Linq.Expressions;
using ApiProduct.Domain.Core.Repositories;
using ApiProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProduct.Domain.Infrastructure.Data.Repositories;
public class BaseRepository<T>(SqlContext context) : IBaseRepository<T> where T : Entity
{
    private readonly SqlContext _context = context;

    public virtual async Task<IEnumerable<T>> GetByexpressionAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>()
                             .AsNoTracking()
                             .Where(predicate)
                             .ToListAsync();
    }

    public virtual async Task<T?> GetByCodigoAsync(int codigo)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Codigo == codigo);
    }
    public virtual async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public virtual async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
    public virtual async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
