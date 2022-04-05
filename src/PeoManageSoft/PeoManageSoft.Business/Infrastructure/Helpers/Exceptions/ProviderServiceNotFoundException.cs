namespace PeoManageSoft.Business.Infrastructure.Helpers.Exceptions
{
    /// <summary>
    /// Represents errors that occur when service provider tries to get a service.
    /// </summary>
    public class ProviderServiceNotFoundException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Exceptions.ProviderServiceNotFoundException class.
        /// </summary>
        public ProviderServiceNotFoundException() : base("Service not found")
        {

        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Exceptions.ProviderServiceNotFoundException class with the service name.
        /// </summary>
        /// <param name="serviceName">The service name.</param>
        public ProviderServiceNotFoundException(string serviceName) : base($"Service \"{serviceName}\" not found")
        {

        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Exceptions.ProviderServiceNotFoundException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ProviderServiceNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }

        #endregion
    }
}
