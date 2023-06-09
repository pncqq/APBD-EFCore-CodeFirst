namespace CW9.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;
    private const string LogFilePath = "logs.txt";


    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected problem!");

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Unexpected problem!");

            LogExceptionToFile(ex);
        }
    }

    private static void LogExceptionToFile(Exception ex)
    {
        using var writer = File.AppendText(LogFilePath);
        writer.WriteLine($"[{DateTime.Now}] {ex}");
    }
}