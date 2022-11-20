namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// OrderBy sql command
    /// </summary>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    /// <param name="Fields">Entity fields</param>
    /// <param name="IsDesc">Indicates whether sorting will be descending</param>
    internal readonly record struct OrderBy<TEntityField>(IEnumerable<TEntityField> Fields, bool IsDesc = false)
    {

    }
}
