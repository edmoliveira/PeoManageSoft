namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Resources of the application
    /// </summary>
    internal static class ApplicationResource
    {
        #region Properties

        /// <summary>
        ///  Authorization Header Key
        /// </summary>
        public static string AuthorizationHeaderKey => "Authorization";
        /// <summary>
        ///  X-Auth Header Key
        /// </summary>
        public static string XAuthorizationHeaderKey => "X-Auth";
        /// <summary>
        ///  RequestId Header Key
        /// </summary>
        public static string RequestIdHeaderKey => "request-id";
        /// <summary>
        ///  SerialNumber Header Key
        /// </summary>
        public static string SerialNumberHeaderKey => "serial-number";

        #endregion
    }
}
