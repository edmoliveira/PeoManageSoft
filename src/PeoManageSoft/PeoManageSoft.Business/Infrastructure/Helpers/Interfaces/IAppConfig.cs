namespace PeoManageSoft.Business.Infrastructure.Helpers.Interfaces
{
    /// <summary>
    /// Application Configuration
    /// </summary>
    public interface IAppConfig
    {
        #region Properties

        /// <summary>
        /// Relational Database Type
        /// </summary>
        public DatabaseType DatabaseType { get; }
        /// <summary>
        /// The connection used to open the database
        /// </summary>
        public string ConnectionString { get; }
        /// <summary>
        /// The command timeout (in seconds).
        /// </summary>
        public int SqlCommandTimeout { get; }
        /// <summary>
        /// Authnetication token cache address.
        /// </summary>
        public string TokenCacheAddress { get; }
        /// <summary>
        /// Authnetication token cache instance.
        /// </summary>
        public string TokenCacheInstance { get; }
        /// <summary>
        /// Array of Allowed Origins
        /// </summary>
        string[] AllowedOrigins { get; }
        /// <summary>
        /// Array of Allowed Methods
        /// </summary>
        string[] AllowedMethods { get; }
        /// <summary>
        /// Array of Allowed Headers
        /// </summary>
        string[] AllowedHeaders { get; }
        /// <summary>
        /// Swagger Documents
        /// </summary>
        IReadOnlyList<IConfigurationOpenApiInfo> Documents { get; }
        /// <summary>
        /// A URL to the Terms of Service for the API. MUST be in the format of a URL.
        /// </summary>
        string TermsOfServiceOpenApi { get; }
        /// <summary>
        /// The identifying name of the contact person/organization.
        /// </summary>
        string NameOpenApiContact { get; }
        /// <summary>
        /// The URL pointing to the contact information. MUST be in the format of a URL.
        /// </summary>
        string UrlOpenApiContact { get; }
        /// <summary>
        /// The email address of the contact person/organization. MUST be in the format of an email address.
        /// </summary>
        string EmailOpenApiContact { get; }
        /// <summary>
        /// The license name used for the API.
        /// </summary>
        string NameOpenApiLicense { get; }
        /// <summary>
        /// The URL pointing to the contact information. MUST be in the format of a URL.
        /// </summary>
        string UrlOpenApiLicense { get; }
        /// <summary>
        /// Serial mumber of the platform.
        /// </summary>
        string SerialNumber { get; }
        /// <summary>
        /// Value that represents a valid issuer that will be used
        /// to check against the token's issuer.
        /// </summary>
        string IssuerJwtOptions { get; }
        /// <summary>
        /// Value that represents a valid audience that will be used to check
        /// against the token's audience.
        /// </summary>
        string AudienceJwtOptions { get; }
        /// <summary>
        /// Authentication token secrect.
        /// </summary>
        public string AuthTokenSecrect { get; }
        /// <summary>
        /// Authentication Token expiration in minutes.
        /// </summary>
        public double AuthTokenExpireSeconds { get; }

        #endregion
    }
}
