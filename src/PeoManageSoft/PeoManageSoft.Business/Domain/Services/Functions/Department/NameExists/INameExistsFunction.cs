namespace PeoManageSoft.Business.Domain.Services.Functions.Department.NameExists
{
    /// <summary>
    /// Function that determines if the name already exists in the department table.
    /// </summary>
    internal interface INameExistsFunction : IFunctionAsync<NameExistsFunctionRequest, bool>
    {
    }
}
