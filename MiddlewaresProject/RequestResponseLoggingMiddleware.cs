public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Before passing to next middleware
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

        await _next(context); // Call next middleware or endpoint

        // After response is generated
        Console.WriteLine($"Response Status: {context.Response.StatusCode}");
    }
}
