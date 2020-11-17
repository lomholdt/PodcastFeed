using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using PodcastFeed.Api.Exceptions;

namespace PodcastFeed.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                switch (exception)
                {
                    case RssNotParsableException e:
                        await httpContext.SetErrorResponse(e, StatusCodes.Status404NotFound);
                        break;
                    default:
                        await httpContext.SetErrorResponse(exception, StatusCodes.Status500InternalServerError);
                        break;
                }
            }
        }
    }
}
