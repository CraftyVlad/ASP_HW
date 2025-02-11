using ASP_HW.Models;

namespace ASP_HW.Middleware
{
    public class WarriorMiddleware
    {
        private readonly RequestDelegate Next;

        public WarriorMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context, Warrior warrior)
        {
            string result = warrior.Attack();
            await context.Response.WriteAsync(result);
        }
    }
}
