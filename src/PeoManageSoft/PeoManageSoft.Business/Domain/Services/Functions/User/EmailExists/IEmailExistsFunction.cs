namespace PeoManageSoft.Business.Domain.Services.Functions.User.EmailExists
{
    /// <summary>
    /// Function that determines if the email already exists in the user table.
    /// </summary>
    internal interface IEmailExistsFunction : IFunctionAsync<EmailExistsFunctionRequest, bool>
    {
    }
}
