using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.GetByEmail
{
    /// <summary>
    /// Function to get the user by email
    /// </summary>
    internal interface IGetByEmailFunction : IFunctionAsync<string, GetResponse>
    {
    }
}
