using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User encapsulation of logic to access data sources.
    /// </summary>
    internal interface IUserRepository : IBaseRepository<UserEntity>
    {
        #region Methods

        /// <summary>
        /// Query the record in the user table by username/password and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="username">Username</param>
        /// <param name="password">User password</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user entity.
        /// </returns>
        Task<UserEntity> SelectUserAsync(IScope scope, string username, string password);
        /// <summary>
        /// Change the user password in the user table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="username">Username</param>
        /// <param name="oldPassword">User old password</param>
        /// <param name="newPassword">User new password</param>
        /// <returns>Returns true if the password has been changed.</returns>
        Task<bool> ChangePasswordAsync(IScope scope, string username, string oldPassword, string newPassword);

        #endregion
    }
}
