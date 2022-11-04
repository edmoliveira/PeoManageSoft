using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail
{
    /// <summary>
    /// Request of the method
    /// </summary>
    internal sealed class SendEmailRequest
    {
        #region Properties 

        /// <summary>
        /// Email data
        /// </summary>
        public EmailData Data { get; set; }

        #endregion
    }
}
