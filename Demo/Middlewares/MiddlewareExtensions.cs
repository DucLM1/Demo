using Microsoft.AspNetCore.Builder;

namespace Demo.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRedirect301Middleware(this IApplicationBuilder builder) => builder.UseMiddleware<Redirect301Middleware>();
        public static IApplicationBuilder UseCachePageMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<CachePageMiddleware>();
    }
}