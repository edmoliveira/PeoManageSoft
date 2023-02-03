using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add.Models
{
    /// <summary>
    /// Request for the add policy command.
    /// </summary>
    internal sealed class UserPolicy
    {
        #region Properties

        /// <summary>
        /// Resource name
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; set; }

        #endregion
    }
}
