using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Application.User._Models
{
    /// <summary>
    /// Resource
    /// </summary>
    public sealed class UserSchemaResource
    {
        #region Properties

        /// <summary>
        /// Identifier
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; set; }
        /// <summary>
        /// Children
        /// </summary>
        public IEnumerable<UserSchemaResource> Children { get; set; }

        #endregion
    }
}
