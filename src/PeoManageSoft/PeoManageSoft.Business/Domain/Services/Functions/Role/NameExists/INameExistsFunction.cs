namespace PeoManageSoft.Business.Domain.Services.Functions.Role.NameExists
{
    /// <summary>
    /// Function that determines if the name already exists in the role table.
    /// </summary>
    internal interface INameExistsFunction : IFunctionAsync<NameExistsFunctionRequest, bool>
    {
    }
}
