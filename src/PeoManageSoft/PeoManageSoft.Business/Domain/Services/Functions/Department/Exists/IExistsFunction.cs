namespace PeoManageSoft.Business.Domain.Services.Functions.Department.Exists
{
    /// <summary>
    /// Function that determines whether the specified department table contains the record that match the id
    /// </summary>
    internal interface IExistsFunction : IFunctionAsync<long, bool>
    {
    }
}
