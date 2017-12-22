using FluentValidation.Results;
using System.Collections.Generic;

namespace Fan.Exceptions
{
    /// <summary>
    /// The error model class for api operations.
    /// </summary>
    public class ApiError
    {
        public string Message { get; set; }
        public IList<ValidationError> Errors { get; set; }
        public string Detail { get; set; }

        public ApiError(string message, IList<ValidationFailure> errors = null)
        {
            Message = message;
            if (errors != null)
            {
                Errors = new List<ValidationError>();
                foreach (var err in errors)
                {
                    Errors.Add(new ValidationError {
                        ErrorMessage = err.ErrorMessage,
                        PropertyName = err.PropertyName,
                    });
                }
            }
        }
    }
}
