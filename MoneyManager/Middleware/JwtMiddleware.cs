namespace MoneyManager.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
        => _next = next;


    public async Task InvokeAsync(HttpContext context)
    {
        string? token = context.Request.Cookies["jwt"];

        if (token is not null)
        {
            context.Request.Headers.Add("Authorization", "Bearer " + token);
        }

        await _next.Invoke(context);
    }
}