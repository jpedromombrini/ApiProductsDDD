using ApiProduct.Domain.Core.Repositories;
using ApiProduct.Domain.Entities;

namespace ApiProduct.Domain.Infrastructure.Data.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(SqlContext context) : base(context){}
}
