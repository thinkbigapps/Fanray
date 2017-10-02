using Fan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;

namespace Fan.Web.UrlRewrite
{
    public class HttpWwwRewriteMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _settings;
        private ILogger<HttpWwwRewriteMiddleware> _logger;

        public HttpWwwRewriteMiddleware(RequestDelegate next,
            IOptionsSnapshot<AppSettings> options, ILoggerFactory loggerFactory)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next ?? throw new ArgumentNullException(nameof(next));
            _settings = options.Value;
            _logger = loggerFactory.CreateLogger<HttpWwwRewriteMiddleware>();
        }

        public Task Invoke(HttpContext context, IHttpWwwRewriter helper)
        {
            if (helper.ShouldRewrite(_settings, context.Request.GetDisplayUrl(), out string url))
            {
                context.Response.Headers[HeaderNames.Location] = url;
                context.Response.StatusCode = 301;
                context.Response.Redirect(url);
                return Task.CompletedTask;
            }

            return _next(context);
        }
    }
}
