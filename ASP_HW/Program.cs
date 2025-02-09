var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Завдання 1: Логування запитів
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{DateTime.Now}] {context.Request.Method} {context.Request.Path}");
    await next();
});

// Завдання 2: Обробка винятків
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var statusCode = context.Response.StatusCode;
        string message = statusCode switch
        {
            404 => "Page not found",
            401 => "Unauthorized",
            _ => "Internal server error"
        };
        await context.Response.WriteAsync(message);
    });
});

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    if (response.StatusCode == 404)
    {
        await response.WriteAsync("404 - Page not found");
    }
    else if (response.StatusCode == 401)
    {
        await response.WriteAsync("401 - Unauthorized");
    }
});

#region Comment to use second task

// Завдання 3: Middleware для автентифікації
app.Use(async (context, next) =>
{
    if (!context.Request.Query.ContainsKey("secret-token") ||
        context.Request.Query["secret-token"] != "1234")
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("401 Unauthorized");
        return;
    }
    await next();
});

// Основний обробник запитів
app.Run(async (context) =>
{
    await context.Response.WriteAsync("hello!");
    // https://localhost:7158/?secret-token=1234 for testing
});

#endregion

app.Run();
