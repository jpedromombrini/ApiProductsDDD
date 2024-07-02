using ApiProduct.Domain.Core.Repositories;
using ApiProduct.Domain.Core.Services;
using ApiProduct.Domain.Entities;

namespace ApiProduct.Domain.Services;
public class ProdutoService : BaseService<Produto>, IProdutoService
{
    public ProdutoService(IBaseRepository<Produto> repository) : base(repository)
    {
    }
}
