using PeoManageSoft.Business.Domain.Services.Commands.User._Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Request for the add policy command.
    /// </summary>
    internal sealed class AddPolicyRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// User Policies
        /// </summary>
        public IEnumerable<UserPolicy> Policies { get; set; }

        #endregion
    }
}
