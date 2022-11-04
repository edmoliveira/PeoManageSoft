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
        /// Remember password logo guid Variables "{{rememberPasswordLogoGuid}}"
        /// </summary>
        public static string RememberPasswordLogoGuidVariable => "{{rememberPasswordLogoGuid}}";
        /// <summary>
        /// Remember password keys guid Variables "{{rememberPasswordKeysGuid}}"
        /// </summary>
        public static string RememberPasswordKeysGuidVariable => "{{rememberPasswordKeysGuid}}";
        /// <summary>
        /// Remember password keys guid Variables "{{rememberPasswordUrl}}"
        /// </summary>
        public static string RememberPasswordUrlVariable => "{{rememberPasswordUrl}}";
        /// <summary>
        /// Remember password keys guid Variables "{{rememberPasswordLocation}}"
        /// </summary>
        public static string RememberPasswordLocationVariable => "{{rememberPasswordLocation}}";

        #endregion
    }
}
