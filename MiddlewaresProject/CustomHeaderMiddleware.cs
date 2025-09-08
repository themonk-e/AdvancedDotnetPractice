public class CustomHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public CustomHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Hook into the response before it is sent
        context.Response.OnStarting(() =>
        {
            context.Response.Headers["X-App-Version"] = "1.0";
            return Task.CompletedTask;
        });

        await _next(context); // Continue processing the request
    }
}
