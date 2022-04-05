using NLog;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Globalization;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Class to be used on one instance throughout the application per request
    /// </summary>
    public sealed class ApplicationContext : IApplicationContext, ISetApplicationContext
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
                return MappedDiagnosticsLogicalContext.Get(_requestIdName, CultureInfo.InvariantCulture);
            }
        }

        #endregion

        #region Methods public

        /// <summary>
        /// Sets the current logical context item to the specified value.
        /// </summary>
        /// <param name="value">Value of the Request id.</param>
        public void SetRequestId(string value)
        {
            MappedDiagnosticsLogicalContext.Set(_requestIdName, value);
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

        #endregion
    }
}
