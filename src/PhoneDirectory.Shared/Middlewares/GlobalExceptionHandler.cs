using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using PhoneDirectory.Shared.Exceptions;

namespace PhoneDirectory.Shared.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        var response = httpContext.Response;
        response.ContentType = "application/json";

        switch (ex)
        {
            case AppException e:
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                break;
            default:
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
                break;
        }

        var result = JsonSerializer.Serialize(new {message = ex?.Message});
        await response.WriteAsync(result);
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
}