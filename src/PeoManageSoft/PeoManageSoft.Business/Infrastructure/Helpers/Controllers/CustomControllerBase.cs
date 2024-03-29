﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using System.Diagnostics;
using System.Net;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Controllers
{
    /// <summary>
    /// A custom base class for an MVC controller without view support.
    /// </summary>
    public class CustomControllerBase : ControllerBase
    {
        #region Constants

        /// <summary>
        /// Create, read, update and delete are the four basic operations of the system.
        /// </summary>
        protected const string Crud_GroupName = "CRUD";
        /// <summary>
        /// Services related to system security.
        /// </summary>
        protected const string Security_GroupName = "Security";

        #endregion

        #region Properties protected 

        /// <summary>
        /// Log
        /// </summary>
        protected ILogger Logger { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Helpers.Controllers.CustomControllerBase class.
        /// </summary>
        /// <param name="logger">Log</param>
        public CustomControllerBase(ILogger logger)
        {
            Logger = logger;
        }

        #endregion

        #region Methods protected

        /// <summary>
        /// Action Result with Try..Catch
        /// </summary>
        /// <param name="func">Funciton with return "IActionResult"</param>
        /// <returns>The contract that represents the result.</returns>
        [NonAction]
        protected IActionResult TryActionResult(Func<IActionResult> func)
        {
            try
            {

                if (func == null)
                {
                    Logger.LogError($"Argument {nameof(func)} is null.");

                    return InternalServerError();
                }

                return func();
            }
            catch (AggregateException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (RequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (CustomHttpRequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (Exception exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
        }

        /// <summary>
        /// Action Result with Try..Catch (Stopwatch)
        /// </summary>
        /// <param name="func">Funciton with return "IActionResult"</param>
        /// <returns>The contract that represents the result.</returns>
        [NonAction]
        protected IActionResult TryActionResult(Func<Stopwatch, IActionResult> func)
        {
            try
            {
                Stopwatch stopwatch = new();

                stopwatch.Start();

                if (func == null)
                {
                    Logger.LogError($"Argument {nameof(func)} is null.");

                    return InternalServerError();
                }

                return func(stopwatch);
            }
            catch (AggregateException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (RequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (CustomHttpRequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (Exception exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
        }

        /// <summary>
        /// Action Result with Try..Catch [Async]
        /// </summary>
        /// <param name="func">Funciton with return "IActionResult"</param>
        /// <returns>The contract that represents the result.</returns>
        [NonAction]
        protected async Task<IActionResult> TryActionResultAsync(Func<Task<IActionResult>> func)
        {
            try
            {
                if (func == null)
                {
                    Logger.LogError($"Argument {nameof(func)} is null.");

                    return InternalServerError();
                }

                return await func().ConfigureAwait(false);
            }
            catch (AggregateException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (RequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (CustomHttpRequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (Exception exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
        }

        /// <summary>
        /// Action Result with Try..Catch [Async] (Stopwatch)
        /// </summary>
        /// <param name="func">Funciton with return "IActionResult"</param>
        /// <returns>The contract that represents the result.</returns>
        [NonAction]
        protected async Task<IActionResult> TryActionResultAsync(Func<Stopwatch, Task<IActionResult>> func)
        {
            try
            {
                Stopwatch stopwatch = new();

                stopwatch.Start();

                if (func == null)
                {
                    Logger.LogError($"Argument {nameof(func)} is null.");

                    return InternalServerError();
                }

                return await func(stopwatch).ConfigureAwait(false);
            }
            catch (AggregateException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (RequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (CustomHttpRequestException exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
            catch (Exception exception)
            {
                return ManageExceptionOfTryActionResult(exception);
            }
        }

        /// <summary>
        /// Validates the model state whether it is invalid or not.
        /// </summary>
        /// <exception cref="RequestException">Represents errors that occur during application execution (Request Data)</exception>
        [NonAction]
        protected void ValidateModelState()
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string>? errors = ModelState.Values.SelectMany(v => v.Errors).DefaultIfEmpty().Select(c => c.ErrorMessage);

                List<string> messageList = errors != null ? errors.ToList() : new();

                throw new RequestException(HttpStatusCode.BadRequest, messageList);
            }
        }

        /// <summary>
        /// Creates an QuixaPartnersApi.Helpers.InternalServerErrorResult that produces a Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError response.
        /// </summary>
        /// <returns>The created QuixaPartnersApi.Helpers.InternalServerErrorResult for the response.</returns>
        [NonAction]
        protected virtual InternalServerErrorResult InternalServerError()
        {
            return new InternalServerErrorResult();
        }

        /// <summary>
        /// Creates an QuixaPartnersApi.Helpers.InternalServerErrorResult that produces a Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError response.
        /// </summary>
        /// <param name="value">An error object to be returned to the client.</param>
        /// <returns>The created QuixaPartnersApi.Helpers.InternalServerErrorObjectResult for the response.</returns>
        [NonAction]
        protected virtual InternalServerErrorObjectResult InternalServerErrorObject(object value)
        {
            return new InternalServerErrorObjectResult(value);
        }

        /// <summary>
        /// Get error messages of the Model State.
        /// </summary>
        /// <returns>Erros</returns>
        [NonAction]
        protected virtual IEnumerable<string> GetErrorMessages()
        {
            return ModelState.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage);
        }

        [NonAction]
        protected static object MakeObjectResult(object message, HttpStatusCode statusCode)
        {
            return new { Error = message, Status = (int)statusCode };
        }

        [NonAction]
        protected static string GetMethodBeginMessage(string methodName)
        {
            return string.Concat("Begin: ", methodName);
        }

        [NonAction]
        protected static string GetMethodEndMessage(string methodName, long requestTimeMilliseconds)
        {
            return string.Concat("End: ", methodName, " (Request finished in ", requestTimeMilliseconds, "ms)");
        }

        #endregion

        #region Method private

        /// <summary>
        /// Handle the TryActionResult exception
        /// </summary>
        /// <param name="aggregateException">Represents one or more errors that occur during application execution.</param>
        /// <returns>The contract that represents the result.</returns>
        private IActionResult ManageExceptionOfTryActionResult(AggregateException aggregateException)
        {
            foreach (var exception in aggregateException.Flatten().InnerExceptions)
            {
                if (exception is RequestException requestException)
                {
                    return new ObjectResult(MakeObjectResult(requestException.Message, requestException.StatusCode))
                    {
                        StatusCode = (int)requestException.StatusCode
                    };
                }
                else if (exception is CustomHttpRequestException customException)
                {
                    return HttpRequestExceptionObject(customException);
                }
                else
                    Logger.LogError(exception, exception.Message);
            }

            return InternalServerError();
        }

        /// <summary>
        /// Handle the TryActionResult exception
        /// </summary>
        /// <param name="exception">Represents errors that occur during application execution.</param>
        /// <returns>The contract that represents the result.</returns>
        private IActionResult ManageExceptionOfTryActionResult(Exception exception)
        {
            if (exception is RequestException requestException)
            {
                return new ObjectResult(MakeObjectResult(requestException.Message, requestException.StatusCode))
                {
                    StatusCode = (int)requestException.StatusCode
                };
            }
            else if (exception is CustomHttpRequestException customException)
            {
                return HttpRequestExceptionObject(customException);
            }

            Logger.LogError(exception, exception.Message);

            return InternalServerError();
        }

        private ObjectResult HttpRequestExceptionObject(CustomHttpRequestException exception)
        {
            string message = "Internal Server Error";

            ObjectResult result = new(MakeObjectResult(message, HttpStatusCode.InternalServerError))
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            if (exception != null)
            {
                Logger.LogError(exception, string.Concat("[", exception.RequestUri, "|", exception.StatusCode, "] = ", exception.Message));

                result = new(MakeObjectResult(message, exception.StatusCode))
                {
                    StatusCode = (int)exception.StatusCode
                };
            }

            return result;
        }

        #endregion
    }
}
