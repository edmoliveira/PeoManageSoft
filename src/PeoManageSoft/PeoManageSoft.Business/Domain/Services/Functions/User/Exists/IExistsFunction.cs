namespace PeoManageSoft.Business.Domain.Services.Functions.User.Exists
{
    /// <summary>
    /// Function that determines whether the specified user table contains the record that match the id
    /// </summary>
    internal interface IExistsFunction : IFunctionAsync<long, bool>
    {
    }
}
