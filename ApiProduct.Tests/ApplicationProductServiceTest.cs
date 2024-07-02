using AutoMapper;
using Moq;
using ApiProduct.Domain.Entities;
using ApiProduct.Application.Dtos;
using ApiProduct.Domain.Services;
using ApiProduct.Domain.Core.Repositories;

namespace ApiProduct.Tests;
public class ApplicationProductServiceTest
{
    private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly ProdutoService _produtoService;

    public ApplicationProductServiceTest()
    {
        _produtoRepositoryMock = new Mock<IProdutoRepository>();
        _mapperMock = new Mock<IMapper>();
        _produtoService = new ProdutoService(_produtoRepositoryMock.Object);
    }

    [Fact]
    public async Task GetByexpressionAsync_ReturnsPaginatedList()
    {
        // Arrange
        var filter = new ProdutoFilterDto(1, "Test", "Ativo", DateTime.MinValue, DateTime.MinValue, 10, "Fornecedor teste", "12345678901234", 1, 10);

        var produtos = new List<Produto>
        {
            new Produto { Codigo = 1, Descricao = "Test Produto", CnpjFornecedor = "12345678901234", DescricaoFornecedor = "Fornecedor Teste", Validade = DateTime.Now, Fabricacao = DateTime.Now, Situacao = "Ativo" },
            // Adicione mais produtos conforme necessário para o teste
        };

        _produtoRepositoryMock.Setup(service => service.GetByexpressionAsync(x => x.Codigo == filter.Codigo))
                           .ReturnsAsync(produtos);

        var produtosDto = produtos.Select(p => new ProdutoDto(p.Codigo, p.Descricao, p.Situacao, p.Fabricacao, p.Validade, p.CodigoFornecedor, p.DescricaoFornecedor,p.CnpjFornecedor)).ToList();

        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<ProdutoDto>>(It.IsAny<IEnumerable<Produto>>()))
                   .Returns(produtosDto);

        // Act
        var result = await _produtoService.GetByexpressionAsync(x => x.Codigo == filter.Codigo);

        // Assert
        Assert.NotNull(result);        
    }
}
