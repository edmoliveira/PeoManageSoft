using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.GetByAuthentication
{
    /// <summary>
    /// Function to get the user by login and password
    /// </summary>
    internal interface IGetByAuthenticationFunction : IFunctionAsync<GetByAuthenticationRequest, GetResponse>
    {
    }
}
