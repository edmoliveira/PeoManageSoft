using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources
{
    /// <summary>
    /// Platform Email Template Catalog.
    /// </summary>
    internal sealed class EmailTemplatesCatalogResource : IEmailTemplatesCatalogResource
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
        /// <summary>
        /// Active user email template.
        /// </summary>
        public EmailTemplateResource ActiveUser { get; set; }
        /// <summary>
        /// Active user email template.
        /// </summary>
        IEmailTemplateResource IEmailTemplatesCatalogResource.ActiveUser => ActiveUser;

        #endregion
    }
}
