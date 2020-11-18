using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using PodcastFeed.Api.Exceptions;

namespace PodcastFeed.Api.Middleware
{
    public class AmIUpMiddleware
    {
        private readonly RequestDelegate _next;

        public AmIUpMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/")
            {
                await httpContext.Response.WriteAsync("ok");
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
