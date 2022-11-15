namespace PeoManageSoft.Business.Domain.Services.Functions.Title.NameExists
{
    /// <summary>
    /// Function that determines if the name already exists in the title table.
    /// </summary>
    internal interface INameExistsFunction : IFunctionAsync<NameExistsFunctionRequest, bool>
    {
    }
}
