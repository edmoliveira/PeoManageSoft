using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models;

namespace PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail.Interfaces
{
    /// <summary>
    /// Provides a creator to create an email layout "Remember Password".
    /// </summary>
    internal interface IRememberPasswordEmailCreator
    {
        #region Methods

        /// <summary>
        /// Create the object of the class Salep.Domain.Service.Messages.Models.EmailData
        /// </summary>
        /// <param name="to">Email address that will be sent</param>
        /// <param name="urlToken">Url with token.</param>
        /// <param name="location">Where the password reminder request was made</param>
        /// <returns>EmailData</returns>
        EmailData CreateEmail(string to, string urlToken, string location);

        #endregion
    }
}
