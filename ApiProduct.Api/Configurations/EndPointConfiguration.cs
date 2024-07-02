using ApiProduct.Api.EndPoints;

namespace ApiProduct.Api.Configurations;
public static class EndPointConfiguration
{
    public static void AddEndpoints(this WebApplication app)
    {        
        app.AddProductEndPoint();
    }
}
