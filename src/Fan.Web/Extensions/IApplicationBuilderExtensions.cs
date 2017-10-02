using Fan.Web.MetaWeblog;
using Fan.Web.UrlRewrite;

namespace Microsoft.AspNetCore.Builder
{
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="MetaWeblogMiddleware"/> to the application's request pipeline.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMetablog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MetaWeblogMiddleware>();
        }

        public static IApplicationBuilder UseHttpWwwRewrite(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpWwwRewriteMiddleware>();
        }
    }
}
