namespace PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken
{
    /// <summary>
    /// Create token command.
    /// </summary>
    internal interface ICreateTokenCommand : ICommandAsync<CreateTokenRequest, CreateTokenResponse>
    {
    }
}