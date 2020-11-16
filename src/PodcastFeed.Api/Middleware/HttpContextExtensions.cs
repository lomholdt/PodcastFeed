using Microsoft.AspNetCore.Http;
using PodcastFeed.Api.Models;
using System;
using System.Threading.Tasks;

namespace PodcastFeed.Api.Middleware
{
    public static class HttpContextExtension
    {
        public static async Task SetErrorResponse(this HttpContext context, Exception e, int statusCode)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = statusCode;
                var response = new ErrorResponse(e.GetType().ToString(), statusCode);
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
