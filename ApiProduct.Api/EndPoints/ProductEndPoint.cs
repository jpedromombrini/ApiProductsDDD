using ApiProduct.Application.Dtos;
using ApiProduct.Application.Services;

namespace ApiProduct.Api.EndPoints;
public static class ProductEndPoint
{
    public static void AddProductEndPoint(this WebApplication app)
    {
        var routes = app.MapGroup("api/products");
        app.MapGet("", async (
            ProdutoFilterDto filter,
            IApplicationProductService service
        ) =>
            Results.Ok(await service.GetByexpressionAsync(filter))
        )
        .Produces<IEnumerable<ProdutoDto>>(StatusCodes.Status200OK)        
        .WithName("GetProducts")
        .WithTags("Products");

        app.MapGet("{codigo}", async (
            int codigo,
            IApplicationProductService service
        ) =>
            Results.Ok(await service.GetByCodigoAsync(codigo))
        )
        .Produces<ProdutoDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("GetProductsByCodigo")
        .WithTags("Products");

        app.MapPost("", async (
            ProdutoDto req,
            IApplicationProductService service
        ) =>
        {
            await service.AddAsync(req);
            return Results.Created();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest)
        .WithName("PostProduct")
        .WithTags("Products");

        app.MapPut("", async (
            ProdutoDto req,
            IApplicationProductService service
        ) =>{
            await service.UpdateAsync(req);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest)
        .WithName("PutProduct")
        .WithTags("Products");

        app.MapDelete("{codigo}", async(
            int codigo,
            IApplicationProductService service
        )=>{
            await service.RemoveAsync(codigo);
            return Results.NoContent();
        });
    }
}
