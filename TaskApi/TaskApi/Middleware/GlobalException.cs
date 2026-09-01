using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace TaskApi.Middleware
{
    public class GlobalException 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalException> _logger;

        public GlobalException(RequestDelegate next , ILogger<GlobalException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await WriteProblemDetails(context, 400, "TitleTest", exception.Message);
            }
        }

        public async Task WriteProblemDetails(HttpContext ctx, int status, string title, string detail)
        {
            ctx.Response.StatusCode = status;
            ctx.Response.ContentType = "application/problem+json";
            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail
            };
            await ctx.Response.WriteAsJsonAsync(problem);
        }
    }
}
