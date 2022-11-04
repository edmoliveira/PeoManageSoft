using System.Collections.Specialized;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail
{
    /// <summary>
    /// Response of the method
    /// </summary>
    internal sealed class SendEmailResponse
    {
        #region Properties

        /// <summary>
        /// Gets the email headers that are transmitted with this email message.
        /// </summary>
        public StringDictionary Headers { get; set; }

        #endregion
    }
}
