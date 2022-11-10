namespace PeoManageSoft.Business.Domain.Services.Functions.Title.Exists
{
    /// <summary>
    /// Function that determines whether the specified title table contains the record that match the id
    /// </summary>
    internal interface IExistsFunction : IFunctionAsync<long, bool>
    {
    }
}
