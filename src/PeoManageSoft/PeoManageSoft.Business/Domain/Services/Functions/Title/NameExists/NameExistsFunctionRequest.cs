namespace PeoManageSoft.Business.Domain.Services.Functions.Title.NameExists
{
    /// <summary>
    /// Request data.
    /// </summary>
    /// <param name="Name">Title name.</param>
    /// <param name="TitleId">Ignore this identifier in name search.</param>
    internal sealed record NameExistsFunctionRequest(string Name, long? TitleId = null)
    {
    }
}
