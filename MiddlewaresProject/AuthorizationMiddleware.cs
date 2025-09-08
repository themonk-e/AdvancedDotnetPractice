public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization")){
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Missing Authorization headers");
            return;
        }
        await _next(context);
    }
}
