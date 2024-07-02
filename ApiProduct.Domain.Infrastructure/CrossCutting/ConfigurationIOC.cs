using ApiProduct.Application.Mappers;
using ApiProduct.Application.Services;
using ApiProduct.Domain.Core.Notifications;
using ApiProduct.Domain.Core.Repositories;
using ApiProduct.Domain.Core.Services;
using ApiProduct.Domain.Infrastructure.Data.Repositories;
using ApiProduct.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiProduct.Domain.Infrastructure.CrossCutting;
public static class ConfigurationIOC
{
    public static void Register(this IServiceCollection services)
    {
        services.AddScoped<IApplicationProductService, ApplicationProductService>();
        services.AddScoped<INotificator, Notificator>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddAutoMapper(typeof(ProdutoMapper).Assembly);
    }
}
