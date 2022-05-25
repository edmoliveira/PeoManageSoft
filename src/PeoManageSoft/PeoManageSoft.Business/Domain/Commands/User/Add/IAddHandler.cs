namespace PeoManageSoft.Business.Domain.Commands.User.Add
{
    /// <summary>
    /// Handles all commands to add the user.
    /// </summary>
    internal interface IAddHandler : IHandlerAsync<AddRequest, AddResponse>
    {
    }
}
