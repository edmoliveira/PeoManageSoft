using PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication
{
    /// <summary>
    /// Handles all queries to get the user by authentication.
    /// </summary>
    internal interface IGetByAuthenticationHandler : IHandlerAsync<GetByAuthenticationRequest, GetByAuthenticationResponse>
    {
    }
}
