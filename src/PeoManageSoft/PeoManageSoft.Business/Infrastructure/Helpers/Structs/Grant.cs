namespace PeoManageSoft.Business.Infrastructure.Helpers.Structs
{
    /// <summary>
    /// User permissions
    /// </summary>
    /// <param name="Create">Can create</param>
    /// <param name="Read">Can Read</param>
    /// <param name="Update">Can Update</param>
    /// <param name="Delete">Can delete</param>
    public readonly record struct Grant(bool Create, bool Read, bool Update, bool Delete)
    {
        /// <summary>
        /// Gets user permissions description
        /// </summary>
        /// <returns>Returns user permissions description</returns>
        public override string ToString()
        {
            return $"Create: {Create}; Read: {Read}; Update: {Update}; Delete: {Delete}";
        }
    }
}