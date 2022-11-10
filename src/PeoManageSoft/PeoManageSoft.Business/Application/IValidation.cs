using FluentValidation;

namespace PeoManageSoft.Business.Application
{
    /// <summary>
    /// Application layer validation object
    /// </summary>
    /// <typeparam name="T">The type of the object being validated</typeparam>
    internal interface IValidation<T> : IValidator<T>
    {
        #region Methods

        /// <summary>
        /// Validates the object and asynchronously using Task.
        /// </summary>
        /// <param name="request">The object being validated</param>
        /// <exception cref="RequestException">Represents errors that occur during application execution (Request Data).</exception>
        Task RunValidationAsync(T request);

        #endregion
    }
}
