using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using System.Net;

namespace PeoManageSoft.Business.Application
{
    /// <summary>
    /// Base class for object validation<.
    /// </summary>
    /// <typeparam name="T">The type of the object being validated</typeparam>
    public class BaseValidation<T> : AbstractValidator<T>, IValidation<T>
    {
        #region Methods

        #region public

        /// <summary>
        /// Validates the object and asynchronously using Task.
        /// </summary>
        /// <param name="request">The object being validated</param>
        /// <exception cref="RequestException">Represents errors that occur during application execution (Request Data).</exception>
        public async Task RunValidationAsync(T request)
        {
            var validatorResult = await ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                throw new RequestException(HttpStatusCode.BadRequest, validatorResult.Errors);
            }
        }

        #endregion

        #endregion
    }
}
