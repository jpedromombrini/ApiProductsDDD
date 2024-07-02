using System.Net;

namespace ApiProduct.Api.Middlewares;
public class ExceptionMiddleware(
    RequestDelegate next, 
    ILogger<ExceptionMiddleware> logger)
{
     private readonly RequestDelegate _next = next;
    private readonly ILogger _logger = logger;    

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception {ex.Message}");
            HandleExceptionAsync(httpContext, ex);
        }
    }

    private static void HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    }
}
