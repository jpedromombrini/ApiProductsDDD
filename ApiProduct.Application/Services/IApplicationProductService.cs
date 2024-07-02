using System.Linq.Expressions;
using ApiProduct.Application.Dtos;

namespace ApiProduct.Application.Services;
public interface IApplicationProductService
{
    Task AddAsync(ProdutoDto produtoDto);

    Task UpdateAsync(ProdutoDto produtoDto);

    Task RemoveAsync(int codigo);
    
    Task<PaginatedListDto<ProdutoDto>> GetByexpressionAsync(ProdutoFilterDto filter);

    Task<ProdutoDto?> GetByCodigoAsync(int codigo);
}
