using System.Collections.Specialized;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser
{
    /// <summary>
    /// Function to send an email with token in the url to activate the user.
    /// </summary>
    internal interface ISendEmailToActiveUserFunction : IFunctionAsync<SendEmailToActiveUserFunctionRequest, StringDictionary>
    {
    }
}
