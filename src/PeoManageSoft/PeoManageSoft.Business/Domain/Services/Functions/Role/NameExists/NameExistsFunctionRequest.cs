namespace PeoManageSoft.Business.Domain.Services.Functions.Role.NameExists
{
    /// <summary>
    /// Request data.
    /// </summary>
    /// <param name="Name">Role name.</param>
    /// <param name="RoleId">Ignore this identifier in name search.</param>
    internal sealed record NameExistsFunctionRequest(string Name, long? RoleId = null)
    {
    }
}
