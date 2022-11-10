namespace PeoManageSoft.Business.Domain.Services.Functions.User.LoginExists
{
    /// <summary>
    /// Request data.
    /// </summary>
    /// <param name="Login">User login.</param>
    /// <param name="UserId">Ignore this identifier in email search.</param>
    internal sealed record LoginExistsFunctionRequest(string Login, long? UserId = null)
    {
    }
}
