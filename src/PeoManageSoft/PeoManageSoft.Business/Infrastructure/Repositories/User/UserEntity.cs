using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// Mapping to the database user table.
    /// </summary>
    public class UserEntity : IEntity
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User login
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// Full username
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Short username
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// The name that describes user's job or position.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// User department
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User bussiness phone
        /// </summary>
        public string BussinessPhone { get; set; }
        /// <summary>
        /// User mobile phone
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Indicates the last location where the user logged in "Longitude and latitude"
        /// </summary>
        public string Location { get; set; }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Get the parameters to the insert sql statement
        /// </summary>
        /// <returns>Parameters</returns>
        public object GetInsertParameters()
        {
            return new
            {
                User,
                Password,
                Role,
                Name,
                ShortName,
                Title,
                Department,
                Email,
                BussinessPhone,
                MobilePhone,
                Location
            };
        }

        /// <summary>
        /// Get the parameters to the update sql statement
        /// </summary>
        /// <returns>Parameters</returns>
        public object GetUpdateParameters()
        {
            return new
            {
                Id,
                User,
                Role,
                Name,
                ShortName,
                Title,
                Department,
                Email,
                BussinessPhone,
                MobilePhone,
                Location
            };
        }

        #endregion

        #endregion
    }
}
