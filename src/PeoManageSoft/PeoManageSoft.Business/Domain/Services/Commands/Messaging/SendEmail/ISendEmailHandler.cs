namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail
{
    /// <summary>
    /// Handles all commands to send email.
    /// </summary>
    internal interface ISendEmailHandler : IHandlerAsync<SendEmailRequest, SendEmailResponse>
    {
    }
}
