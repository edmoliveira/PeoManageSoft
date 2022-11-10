using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.GetByPasswordToken
{
    /// <summary>
    /// Function to get the user by passwordToken
    /// </summary>
    internal interface IGetByPasswordTokenFunction : IFunctionAsync<string, GetResponse>
    {
    }
}
