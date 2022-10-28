namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Add user command.
    /// </summary>
    internal interface IAddCommand : ICommandScopeAsync<AddRequest, AddResponse>
    {
    }
}
