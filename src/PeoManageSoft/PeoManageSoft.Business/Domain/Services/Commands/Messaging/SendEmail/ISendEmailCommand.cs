namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail
{
    /// <summary>
    /// Send email command.
    /// </summary>
    internal interface ISendEmailCommand : ICommandAsync<SendEmailRequest, SendEmailResponse>
    {
    }
}
