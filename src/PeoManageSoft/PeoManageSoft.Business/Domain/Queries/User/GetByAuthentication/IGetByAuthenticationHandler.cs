using PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication.Response;

namespace PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication
{
    /// <summary>
    /// Handles all queries to get the user by authentication.
    /// </summary>
    internal interface IGetByAuthenticationHandler : IHandlerAsync<GetByAuthenticationRequest, GetByAuthenticationResponse>
    {
    }
}
