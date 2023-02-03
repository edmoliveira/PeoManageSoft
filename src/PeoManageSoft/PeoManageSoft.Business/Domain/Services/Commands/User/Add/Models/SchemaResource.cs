using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add.Models
{
    /// <summary>
    /// Resource
    /// </summary>
    internal sealed class SchemaResource
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
        public IEnumerable<SchemaResource> Children { get; set; }

        #endregion
    }
}
