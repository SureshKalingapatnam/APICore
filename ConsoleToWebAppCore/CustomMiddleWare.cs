using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is from custom 1 \n");
            await next(context);
            await context.Response.WriteAsync("This is from custom 2 \n");
        }
    }
}
