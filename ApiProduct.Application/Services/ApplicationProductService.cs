using ApiProduct.Application.Dtos;
using ApiProduct.Domain.Core.Services;
using ApiProduct.Domain.Entities;
using ApiProduct.Domain.Core.Notifications;
using AutoMapper;

namespace ApiProduct.Application.Services;
public class ApplicationProductService(
    IProdutoService produtoService,
    INotificator notificator,
    IMapper mapper) : IApplicationProductService
{
    private readonly IProdutoService _produtoService = produtoService;
    private readonly IMapper _mapper = mapper;
    private readonly INotificator _notificator = notificator;
    public async Task<PaginatedListDto<ProdutoDto>> GetByexpressionAsync(ProdutoFilterDto filter)
    {
        var products = await _produtoService
                                .GetByexpressionAsync(x =>
                                    filter.Codigo == 0 || x.Codigo == filter.Codigo
                                  && string.IsNullOrEmpty(filter.Descricao) || x.Descricao.Contains(filter.Descricao, StringComparison.CurrentCultureIgnoreCase)
                                  && string.IsNullOrEmpty(filter.CnpjFornecedor) || x.CnpjFornecedor.Equals(filter.CnpjFornecedor)
                                  && string.IsNullOrEmpty(filter.DescricaoFornecedor) || x.DescricaoFornecedor.Equals(filter.DescricaoFornecedor)
                                  && filter.Validade == DateTime.MinValue || x.Validade == filter.Validade
                                  && filter.Fabricacao == DateTime.MinValue || x.Fabricacao == filter.Fabricacao
                                  && filter.Situacao == x.Situacao);
        var count = products.Count();
        var productsPaginated = products.Skip((filter.NumeroPagina - 1) * filter.TamanhoPagina)
                                        .Take(filter.TamanhoPagina)
                                        .ToList();
        var productsDto = _mapper.Map<IEnumerable<ProdutoDto>>(productsPaginated);

        return new PaginatedListDto<ProdutoDto>(productsDto.ToList(), count, filter.NumeroPagina, filter.TamanhoPagina);
    }
    public async Task<ProdutoDto?> GetByCodigoAsync(int codigo)
    {
        var product = await _produtoService.GetByCodigoAsync(codigo);
        return _mapper.Map<ProdutoDto>(product);
    }

    public async Task AddAsync(ProdutoDto produtoDto)
    {
        if (produtoDto.Fabricacao >= produtoDto.Validade)
        {
            _notificator.Handle(new Notification("Fabricação não pode ser maior que data de validade"));
            return;
        }
        var product = _mapper.Map<Produto>(produtoDto);
        await _produtoService.AddAsync(product);
    }
    public async Task RemoveAsync(int codigo)
    {
        var product = await _produtoService.GetByCodigoAsync(codigo);
        if (product is null)
        {
            _notificator.Handle(new Notification("nenhum produto encontrado com o código informado"));
            return;
        }
        product.Situacao = "Inativo";
        await _produtoService.UpdateAsync(product);
    }

    public async Task UpdateAsync(ProdutoDto produtoDto)
    {
        var product = await _produtoService.GetByCodigoAsync(produtoDto.Codigo);
        if (product is null)
        {
            _notificator.Handle(new Notification("Nenhum produto encontrado com o código informado"));
            return;
        }
        if (produtoDto.Fabricacao >= produtoDto.Validade)
        {
            _notificator.Handle(new Notification("Fabricação não pode ser maior que data de validade"));
            return;
        }
        product = _mapper.Map<Produto>(produtoDto);
        await _produtoService.UpdateAsync(product);
    }
}
