namespace Fan.Exceptions
{
    /// <summary>
    /// Model class for validation error information.
    /// </summary>
    /// <remarks>
    /// Because FluentValidation.Results.ValidationFailure has too much info I don't need.
    /// </remarks>
    public class ValidationError
    {
        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The name of the property that causes the error.
        /// </summary>
        public string PropertyName { get; set; }
    }
}
