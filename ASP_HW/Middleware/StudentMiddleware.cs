using Microsoft.Extensions.Options;
using System.Text.Json;
using ASP_HW;

public class StudentMiddleware
{
    private readonly RequestDelegate Next;
    private readonly Student Student;

    public StudentMiddleware(RequestDelegate next, IOptions<Student> studentOptions)
    {
        Next = next;
        Student = studentOptions.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/home")
        {
            var response = JsonSerializer.Serialize(Student);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(response);
            return;
        }

        if (context.Request.Path == "/academy")
        {
            var response = JsonSerializer.Serialize(Student.DisciplineList);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(response);
            return;
        }

        await Next(context);
    }
}
