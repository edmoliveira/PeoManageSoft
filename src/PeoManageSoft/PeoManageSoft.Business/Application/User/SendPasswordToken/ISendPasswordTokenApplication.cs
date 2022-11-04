namespace PeoManageSoft.Business.Application.User.SendPasswordToken
{
    /// <summary>
    /// Application layer to send an email to the user to change his password.
    /// </summary>
    internal interface ISendPasswordTokenApplication : IApplicationAsync<SendPasswordTokenRequest>
    {
    }
}
