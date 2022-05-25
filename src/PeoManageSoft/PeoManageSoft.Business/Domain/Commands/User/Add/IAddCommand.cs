namespace PeoManageSoft.Business.Domain.Commands.User.Add
{
    /// <summary>
    /// Add user command.
    /// </summary>
    internal interface IAddCommand : ICommandScopeAsync<AddRequest, AddResponse>
    {
    }
}
