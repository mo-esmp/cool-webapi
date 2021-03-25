using CoolWebApi.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CoolWebApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ApiExceptionHandlingMiddleware>();
    }
}