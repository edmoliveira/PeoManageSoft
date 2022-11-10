using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models;

namespace PeoManageSoft.Business.Domain.Services.Creators.ActiveUserEmail.Interfaces
{
    /// <summary>
    /// Provides a creator to create an email layout "Active User".
    /// </summary>
    internal interface IActiveUserEmailCreator
    {
        #region Methods

        /// <summary>
        /// Create the object of the class PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailData
        /// </summary>
        /// <param name="to">Email address that will be sent</param>
        /// <param name="urlToken">Url with token.</param>
        /// <returns>EmailData</returns>
        EmailData CreateEmail(string to, string urlToken);

        #endregion
    }
}
