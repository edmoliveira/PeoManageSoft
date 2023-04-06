namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources
{
    /// <summary>
    /// Handles all queries to get the role resources.
    /// </summary>
    internal interface IGetResourcesHandler : IHandlerAsync<GetResourcesRequest, IEnumerable<GetResourcesResponse>>
    {
    }
}
