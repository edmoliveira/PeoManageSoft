namespace PeoManageSoft.Business.Domain.Commands.User.CreateToken
{
    /// <summary>
    /// Handles all commands to create the token.
    /// </summary>
    internal interface ICreateTokenHandler : IHandlerAsync<CreateTokenRequest, CreateTokenResponse>
    {
    }
}
