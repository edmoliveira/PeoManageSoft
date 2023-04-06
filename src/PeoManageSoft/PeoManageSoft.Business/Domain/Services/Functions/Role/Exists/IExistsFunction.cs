namespace PeoManageSoft.Business.Domain.Services.Functions.Role.Exists
{
    /// <summary>
    /// Function that determines whether the specified role table contains the record that match the id
    /// </summary>
    internal interface IExistsFunction : IFunctionAsync<long, bool>
    {
    }
}
