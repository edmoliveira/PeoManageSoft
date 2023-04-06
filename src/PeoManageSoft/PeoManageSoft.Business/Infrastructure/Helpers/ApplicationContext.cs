using NLog;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Class to be used on one instance throughout the application per request
    /// </summary>
    internal sealed class ApplicationContext : IApplicationContext, ISetApplicationContext
    {
        #region Fields private

        /// <summary>
        /// The current logical context named item, as System.String.
        /// </summary>
        private readonly string _requestIdName = "requestId";

        #endregion

        #region Properties

        /// <summary>
        /// Authentication token.
        /// </summary>
        public string Token { get; private set; }
        /// <summary>
        /// Specifies the serial mumber of the platform.
        /// </summary>
        public string SerialNumber { get; private set; }
        /// <summary>
        /// Request id for all transaction in the platform.
        /// </summary>
        public string RequestId
        {
            get
            {
                return ScopeContext.TryGetProperty(_requestIdName, out var value) ? value?.ToString() : string.Empty;
            }
        }
        /// <summary>
        /// Logged in user.
        /// </summary>
        public LoggedUser LoggedUser { get; private set; }

        #endregion

        #region Methods public

        /// <summary>
        /// Sets the current logical context item to the specified value.
        /// </summary>
        /// <param name="value">Value of the Request id.</param>
        public void SetRequestId(string value)
        {
            ScopeContext.PushProperty(_requestIdName, value);
        }

        /// <summary>
        /// Sets the authentication token.
        /// </summary>
        /// <param name="token">Token.</param>
        public void SetToken(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Sets the serial mumber of the platform.
        /// </summary>
        /// <param name="serialNumber">Specifies the serial mumber of the platform.</param>
        public void SetSerialNumber(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        /// <summary>
        /// Sets the logged in user.
        /// </summary>
        /// <param name="loggedUser">Logged in user.</param>
        public void SetLoggedUser(LoggedUser loggedUser)
        {
            LoggedUser = loggedUser;
        }


        #endregion
    }
}
