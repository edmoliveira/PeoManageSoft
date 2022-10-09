namespace PeoManageSoft.Business.Domain.Commands.User.CreateToken
{
    /// <summary>
    /// Create token command.
    /// </summary>
    internal interface ICreateTokenCommand : ICommandAsync<CreateTokenRequest, CreateTokenResponse>
    {
    }
}