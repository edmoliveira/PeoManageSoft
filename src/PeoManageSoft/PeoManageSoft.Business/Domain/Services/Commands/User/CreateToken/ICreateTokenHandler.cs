namespace PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken
{
    /// <summary>
    /// Handles all commands to create the token.
    /// </summary>
    internal interface ICreateTokenHandler : IHandlerAsync<CreateTokenRequest, CreateTokenResponse>
    {
    }
}
