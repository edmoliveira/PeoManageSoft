using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Interfaces
{
    /// <summary>
    /// Application Configuration
    /// </summary>
    internal interface IAppConfig
    {
        #region Properties

        /// <summary>
        /// Specifies the name of the application.
        /// </summary>
        string ApplicationName { get; set; }
        /// <summary>
        /// Specifies the title of the application.
        /// </summary>
        string ApplicationTitle { get; set; }
        /// <summary>
        /// Specifies the language of the application.
        /// </summary>
        ApplicationLanguage ApplicationLanguage { get; set; }
        /// <summary>
        /// Relational Database Type
        /// </summary>
        DatabaseType DatabaseType { get; }
        /// <summary>
        /// The connection used to open the database
        /// </summary>
        string ConnectionString { get; }
        /// <summary>
        /// The command timeout (in seconds).
        /// </summary>
        int SqlCommandTimeout { get; }
        /// <summary>
        /// Authnetication token cache address.
        /// </summary>
        string TokenCacheAddress { get; }
        /// <summary>
        /// Authnetication token cache instance.
        /// </summary>
        string TokenCacheInstance { get; }
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
        string AuthTokenSecrect { get; }
        /// <summary>
        /// Authentication Token expiration in minutes.
        /// </summary>
        double AuthTokenExpireSeconds { get; }
        /// <summary>
        /// Password token secrect.
        /// </summary>
        string PasswordTokenSecrect { get; }
        /// <summary>
        /// Password Token expiration hours.
        /// </summary>
        double PasswordTokenExpireHours { get; }
        /// <summary>
        /// Smtp configuration
        /// </summary>
        ISmtpConfiguration SmtpConfig { get; }
        /// <summary>
        /// Platform Images catalog.
        /// </summary>
        IImagesCatalogResource ImagesCatalog { get; }
        /// <summary>
        /// Platform Email Template Catalog.
        /// </summary>
        IEmailTemplatesCatalogResource EmailTemplatesCatalog { get; }

        #endregion
    }
}
