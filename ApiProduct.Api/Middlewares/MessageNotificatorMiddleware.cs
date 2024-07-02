using System.Text.Json;
using ApiProduct.Domain.Core.Notifications;

namespace ApiProduct.Api.Middlewares;
public class MessageNotificatorMiddleware(
    RequestDelegate next,
    INotificator notificator
)
{
    private readonly RequestDelegate _next = next;
    private INotificator _notificator = notificator;

    public async Task InvokeAsync(HttpContext context)
    {
        if (_notificator.HasNotification())
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            var errors = JsonSerializer.Serialize(_notificator.GetNotifications());
            await context.Response.WriteAsync(errors);
            return;
        }
        await _next(context);
    }
}
