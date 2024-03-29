﻿namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces
{
    /// <summary>
    /// Platform Email Template Catalog.
    /// </summary>
    internal interface IEmailTemplatesCatalogResource
    {
        #region Properties

        /// <summary>
        /// Remember password email template.
        /// </summary>
        IEmailTemplateResource RememberPassword { get; }
        /// <summary>
        /// Active user email template.
        /// </summary>
        IEmailTemplateResource ActiveUser { get; }

        #endregion
    }
}
