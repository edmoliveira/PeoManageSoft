using PeoManageSoft.Business.Domain.Services.Commands.User.Add.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Request for the add schema command.
    /// </summary>
    internal sealed class AddSchemaRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Resources
        /// </summary>
        public IEnumerable<SchemaResource> Resources { get; set; }

        #endregion
    }
}
