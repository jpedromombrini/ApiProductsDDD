using Microsoft.OpenApi.Models;

namespace ApiProduct.Api.Configurations;
public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Product API",
                Description = "Developed by João Pedro Mombrini",
                Contact = new OpenApiContact { Name = "João Pedro Mombrini", Email = "joaopedromombrini@gmail.com" },
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });           
        });
    }
}
