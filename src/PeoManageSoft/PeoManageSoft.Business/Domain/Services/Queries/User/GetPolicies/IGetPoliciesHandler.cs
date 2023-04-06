namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies
{
    /// <summary>
    /// Handles all queries to get the user policies.
    /// </summary>
    internal interface IGetPoliciesHandler : IHandlerAsync<GetPoliciesRequest, IEnumerable<GetPoliciesResponse>>
    {
    }
}
