using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Resources;
using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Aplication configuration
    /// </summary>
    internal sealed class AppConfig : IAppConfig
    {
        #region Properties

        /// <summary>
        /// Minimum login length
        /// </summary>
        public int LoginMinimumLength { get; set; }
        /// <summary>
        /// Minimum password length
        /// </summary>
        public int PasswordMinimumLength { get; set; }

        /// <summary>
        /// Specifies the name of the application.
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// Specifies the title of the application.
        /// </summary>
        public string ApplicationTitle { get; set; }
        /// <summary>
        /// Specifies the language of the application.
        /// </summary>
        public ApplicationLanguage ApplicationLanguage { get; set; }
        /// <summary>
        /// Relational Database Type
        /// </summary>
        public DatabaseType DatabaseType { get; set; }
        /// <summary>
        /// The connection used to open the database
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// The command timeout (in seconds).
        /// </summary>
        public int SqlCommandTimeout { get; set; }
        /// <summary>
        /// Authnetication token cache address.
        /// </summary>
        public string TokenCacheAddress { get; set; }
        /// <summary>
        /// Authnetication token cache instance.
        /// </summary>
        public string TokenCacheInstance { get; set; }
        /// <summary>
        /// Array of Allowed Origins
        /// </summary>
        public string[] AllowedOrigins { get; set; }
        /// <summary>
        /// Array of Allowed Methods
        /// </summary>
        public string[] AllowedMethods { get; set; }
        /// <summary>
        /// Array of Allowed Headers
        /// </summary>
        public string[] AllowedHeaders { get; set; }
        /// <summary>
        /// Swagger Documents
        /// </summary>
        public List<ConfigurationOpenApiInfo> Documents { get; set; }
        /// <summary>
        /// Swagger Documents
        /// </summary>
        IReadOnlyList<IConfigurationOpenApiInfo> IAppConfig.Documents { get { return Documents; } }
        /// <summary>
        /// A URL to the Terms of Service for the API. MUST be in the format of a URL.
        /// </summary>
        public string TermsOfServiceOpenApi { get; set; }
        /// <summary>
        /// The identifying name of the contact person/organization.
        /// </summary>
        public string NameOpenApiContact { get; set; }
        /// <summary>
        /// The URL pointing to the contact information. MUST be in the format of a URL.
        /// </summary>
        public string UrlOpenApiContact { get; set; }
        /// <summary>
        /// The email address of the contact person/organization. MUST be in the format of an email address.
        /// </summary>
        public string EmailOpenApiContact { get; set; }
        /// <summary>
        /// The license name used for the API.
        /// </summary>
        public string NameOpenApiLicense { get; set; }
        /// <summary>
        /// The URL pointing to the contact information. MUST be in the format of a URL.
        /// </summary>
        public string UrlOpenApiLicense { get; set; }
        /// <summary>
        /// Serial mumber of the platform.
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Value that represents a valid issuer that will be used
        /// to check against the token's issuer.
        /// </summary>
        public string IssuerJwtOptions { get; set; }
        /// <summary>
        /// Value that represents a valid audience that will be used to check
        /// against the token's audience.
        /// </summary>
        public string AudienceJwtOptions { get; set; }
        /// <summary>
        /// Authentication token secrect.
        /// </summary>
        public string AuthTokenSecrect { get; set; }
        /// <summary>
        /// Authentication Token expiration in minutes.
        /// </summary>
        public double AuthTokenExpireSeconds { get; set; }
        /// <summary>
        /// Password token secrect.
        /// </summary>
        public string PasswordTokenSecrect { get; set; }
        /// <summary>
        /// Password Token expiration hours.
        /// </summary>
        public double PasswordTokenExpireHours { get; set; }
        /// <summary>
        /// Smtp configuration
        /// </summary>
        public SmtpConfiguration SmtpConfig { get; set; }
        /// <summary>
        /// Smtp configuration
        /// </summary>
        ISmtpConfiguration IAppConfig.SmtpConfig => SmtpConfig;
        /// <summary>
        /// Platform Images catalog.
        /// </summary>
        public ImagesCatalogResource ImagesCatalog { get; set; }
        /// <summary>
        /// Platform Images catalog.
        /// </summary>
        IImagesCatalogResource IAppConfig.ImagesCatalog => ImagesCatalog;
        /// <summary>
        /// Platform Email Template Catalog.
        /// </summary>
        public EmailTemplatesCatalogResource EmailTemplatesCatalog { get; set; }
        /// <summary>
        /// Platform Email Template Catalog.
        /// </summary>
        IEmailTemplatesCatalogResource IAppConfig.EmailTemplatesCatalog => EmailTemplatesCatalog;
        /// <summary>
        /// Platform messages catalog.
        /// </summary>
        public Dictionary<ApplicationLanguage, MessagesCatalogResource> MessagesCatalogResource { get; set; }
        /// <summary>
        /// Platform messages catalog.
        /// </summary>
        IMessagesCatalogResource IAppConfig.MessagesCatalogResource => MessagesCatalogResource[ApplicationLanguage];

        #endregion
    }
}
