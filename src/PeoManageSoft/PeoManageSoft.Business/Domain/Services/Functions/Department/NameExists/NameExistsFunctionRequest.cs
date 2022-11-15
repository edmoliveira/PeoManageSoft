namespace PeoManageSoft.Business.Domain.Services.Functions.Department.NameExists
{
    /// <summary>
    /// Request data.
    /// </summary>
    /// <param name="Name">Department name.</param>
    /// <param name="DepartmentId">Ignore this identifier in name search.</param>
    internal sealed record NameExistsFunctionRequest(string Name, long? DepartmentId = null)
    {
    }
}
