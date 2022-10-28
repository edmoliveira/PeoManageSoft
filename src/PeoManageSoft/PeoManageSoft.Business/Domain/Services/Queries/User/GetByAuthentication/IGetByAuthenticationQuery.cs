using PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication
{
    /// <summary>
    /// Get user by authentication query.
    /// </summary>
    internal interface IGetByAuthenticationQuery : IQueryScopeAsync<GetByAuthenticationRequest, GetByAuthenticationResponse>
    {
    }
}
