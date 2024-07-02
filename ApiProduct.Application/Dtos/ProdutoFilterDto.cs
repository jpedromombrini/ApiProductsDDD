namespace ApiProduct.Application.Dtos;
public record ProdutoFilterDto(
    int Codigo,
    string Descricao,
    string Situacao,
    DateTime Fabricacao,
    DateTime Validade,
    int CodigoFornecedor,
    string DescricaoFornecedor,
    string CnpjFornecedor,
    int NumeroPagina = 1,
    int TamanhoPagina = 10
);

