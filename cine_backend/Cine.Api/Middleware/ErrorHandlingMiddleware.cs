using System.Net;
using System.Text.Json;

namespace Cine.Api.Middleware;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    // private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
        // _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // _logger.LogError(ex, "An error has occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;   // 500 if unexpected
        var result = JsonSerializer.Serialize(new { error = "An error ocurred while processing your request." });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}