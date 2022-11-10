namespace PeoManageSoft.Business.Domain.Services.Functions.User.LoginExists
{
    /// <summary>
    /// Function that determines if the login already exists in the user table.
    /// </summary>
    internal interface ILoginExistsFunction : IFunctionAsync<LoginExistsFunctionRequest, bool>
    {
    }
}
