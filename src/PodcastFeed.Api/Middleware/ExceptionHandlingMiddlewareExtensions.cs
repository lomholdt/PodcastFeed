using Microsoft.AspNetCore.Builder;

namespace PodcastFeed.Api.Middleware
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder) =>
            builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
