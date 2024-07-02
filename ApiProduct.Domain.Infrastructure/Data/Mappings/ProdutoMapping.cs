using ApiProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProduct.Domain.Infrastructure.Data.Mappings;
public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");
        builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd()
                .IsRequired();
        builder.Property(x => x.Descricao)
               .IsRequired()        
               .HasColumnType("varchar(100)");
        builder.Property(x => x.Fabricacao)
                .HasColumnType("timestamp");
        builder.Property(x => x.Situacao)
                .HasColumnType("varchar(7)");
        builder.Property(x => x.Validade)
                .HasColumnType("timestamp");
        builder.Property(x => x.Descricao)
                .HasColumnType("varchar(100)");
        builder.Property(x => x.CnpjFornecedor)
                .HasColumnType("varchar(14)");
        builder.Property(x => x.CodigoFornecedor)
                .HasColumnType("integer");
    }
}
