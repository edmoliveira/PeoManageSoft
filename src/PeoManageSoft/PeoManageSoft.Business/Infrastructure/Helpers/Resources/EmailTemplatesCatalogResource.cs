using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources
{
    /// <summary>
    /// Platform Email Template Catalog.
    /// </summary>
    public sealed class EmailTemplatesCatalogResource : IEmailTemplatesCatalogResource
    {
        #region Properties

        /// <summary>
        /// Remember password email template.
        /// </summary>
        public EmailTemplateResource RememberPassword { get; set; }
        /// <summary>
        /// Remember password email template.
        /// </summary>
        IEmailTemplateResource IEmailTemplatesCatalogResource.RememberPassword => RememberPassword;

        #endregion
    }
}
