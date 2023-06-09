using CW9.Middlewares;

namespace CW9.ExtensionMethods;

public static class LoggingMiddlewareExstension
{
    public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingMiddleware>();
    }
}