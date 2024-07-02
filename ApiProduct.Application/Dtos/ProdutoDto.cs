using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProduct.Application.Dtos;
public record ProdutoDto(
    int Codigo,
    string Descricao,
    string Situacao,
    DateTime Fabricacao,
    DateTime Validade,
    int CodigoFornecedor,
    string DescricaoFornecedor,
    string CnpjFornecedor
);

