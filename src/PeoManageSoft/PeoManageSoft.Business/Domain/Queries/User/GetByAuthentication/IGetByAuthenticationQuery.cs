using PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication.Response;

namespace PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication
{
    /// <summary>
    /// Get user by authentication query.
    /// </summary>
    internal interface IGetByAuthenticationQuery : IQueryScopeAsync<GetByAuthenticationRequest, GetByAuthenticationResponse>
    {
    }
}
