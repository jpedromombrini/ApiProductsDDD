using ApiProduct.Application.Dtos;
using ApiProduct.Domain.Entities;
using AutoMapper;

namespace ApiProduct.Application.Mappers;
public class ProdutoMapper : Profile
{
    public ProdutoMapper()
    {
        CreateMap<Produto, ProdutoDto>()
            .ForMember(prod => prod.Codigo, opt => opt.MapFrom(x => x.Codigo))
            .ForMember(prod => prod.Descricao, opt => opt.MapFrom(x => x.Descricao))
            .ForMember(prod => prod.Situacao, opt => opt.MapFrom(x => x.Situacao))
            .ForMember(prod => prod.Fabricacao, opt => opt.MapFrom(x => x.Fabricacao))
            .ForMember(prod => prod.Validade, opt => opt.MapFrom(x => x.Validade))
            .ForMember(prod => prod.CodigoFornecedor, opt => opt.MapFrom(x => x.CodigoFornecedor))
            .ForMember(prod => prod.DescricaoFornecedor, opt => opt.MapFrom(x => x.DescricaoFornecedor))
            .ForMember(prod => prod.CnpjFornecedor, opt => opt.MapFrom(x => x.CnpjFornecedor))
            .ReverseMap();
    }  
}
