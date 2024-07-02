using ApiProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProduct.Domain.Infrastructure.Data;
public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options)
    {

    }
    public DbSet<Produto> Produtos { get; set; }   
}
