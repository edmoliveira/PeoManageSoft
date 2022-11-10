namespace PeoManageSoft.Business.Domain.Services.Functions.User.EmailExists
{
    /// <summary>
    /// Request data.
    /// </summary>
    /// <param name="Email">User email.</param>
    /// <param name="UserId">Ignore this identifier in email search.</param>
    internal sealed record EmailExistsFunctionRequest(string Email, long? UserId = null)
    {
    }
}
