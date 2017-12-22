using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Net;

namespace Fan.Exceptions
{
    /// <summary>
    /// The exception for the system.
    /// </summary>
    /// <remarks>
    /// Caller should log before throw an exception.  I choose not to pass in ILogger here for max flexibility.
    /// The message giving to this class will be displayed on Error.cshtml.
    /// </remarks>
    public class FanException : Exception
    {
        /// <summary>
        /// The status code to return for API operation.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// A list of <see cref="ValidationFailure"/>. Null if the exception thrown is not
        /// as a result of <see cref="ValidationResult.IsValid"/> being false.
        /// </summary>
        public IList<ValidationFailure> ValidationFailures { get; }

        /// <summary>
        /// Thrown with a message, and optional status code and validation failures.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode">Default to 400.</param>
        /// <param name="validationFailures"></param>
        public FanException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, IList<ValidationFailure> validationFailures = null)
            : base(message)
        {
            StatusCode = statusCode;
            ValidationFailures = validationFailures;
        }

        /// <summary>
        /// Thrown with an exception and optional status code.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="statusCode">Default to 400.</param>
        public FanException(Exception exception, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(exception.Message)
        {
            StatusCode = statusCode;
        }
    }
}