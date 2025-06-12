using Qurbanet.Middlewares;

namespace Qurbanet.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            // Logging Middleware
            app.UseMiddleware<LoggingMiddleware>();
            return app;
        }
    }
}
