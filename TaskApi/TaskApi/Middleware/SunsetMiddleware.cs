namespace TaskApi.Middleware
{
    public class SunsetMiddleware
    {
        private readonly RequestDelegate _next;

        public SunsetMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            if (context.Request.Path.StartsWithSegments("/api/v1"))
            {
                context.Response.Headers["Sunset"] = "15 Augest 2027";
            }
            await _next(context);
        }


    }
}
