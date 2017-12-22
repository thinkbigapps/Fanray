using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Fan.Exceptions
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger<ApiExceptionFilter> _Logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _Logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;
            if (context.Exception is FanException)
            {
                var fanException = context.Exception as FanException;
                context.Exception = null;
                apiError = new ApiError(fanException.Message, fanException.ValidationFailures);
                context.HttpContext.Response.StatusCode = (int)fanException.StatusCode;
                _Logger.LogWarning($"Application thrown error: {fanException.Message}", fanException);
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access");
                context.HttpContext.Response.StatusCode = 401;
                _Logger.LogWarning("Unauthorized Access in Controller Filter.");
            }
            else // Unhandled errors 500
            {
#if !DEBUG
                var msg = "An unhandled error occurred.";
                string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new ApiError(msg)
                {
                    Detail = stack
                };

                context.HttpContext.Response.StatusCode = 500;
                _Logger.LogError(context.Exception, msg);
            }

            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}
