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
        /// <summary>
        /// Application name Variables "{{applicationName}}"
        /// </summary>
        public static string ApplicationNameVariable => "{{applicationName}}";
        /// <summary>
        /// Remember password logo guid Variables "{{emailPasswordLogoGuid}}"
        /// </summary>
        public static string EmailLogoGuidVariable => "{{emailPasswordLogoGuid}}";
        /// <summary>
        /// Remember password keys guid Variables "{{emailPasswordKeysGuid}}"
        /// </summary>
        public static string EmailKeysGuidVariable => "{{emailPasswordKeysGuid}}";
        /// <summary>
        /// Remember password keys guid Variables "{{emailPasswordUrl}}"
        /// </summary>
        public static string EmailUrlVariable => "{{emailPasswordUrl}}";
        /// <summary>
        /// Remember password keys guid Variables "{{rememberPasswordLocation}}"
        /// </summary>
        public static string RememberPasswordLocationVariable => "{{rememberPasswordLocation}}";

        #endregion
    }
}
