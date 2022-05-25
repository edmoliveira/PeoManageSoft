using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// Mapping to the database user table.
    /// </summary>
    internal class UserEntity : IEntity
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; private set; }
        /// <summary>
        /// Indicates whether the user is active
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; private set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public int Role { get; private set; }
        /// <summary>
        /// Full username
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Short username
        /// </summary>
        public string ShortName { get; private set; }
        /// <summary>
        /// User title identifier
        /// </summary>
        public long TitleId { get; private set; }
        /// <summary>
        /// The object that describes user's job or position.
        /// </summary>
        public TitleEntity Title { get; private set; }
        /// <summary>
        /// User department identifier
        /// </summary>
        public long DepartmentId { get; private set; }
        /// <summary>
        /// The object that describes user's department.
        /// </summary>
        public DepartmentEntity Department { get; private set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// User bussiness phone
        /// </summary>
        public string BussinessPhone { get; private set; }
        /// <summary>
        /// User mobile phone
        /// </summary>
        public string MobilePhone { get; private set; }
        /// <summary>
        /// Indicates the last location where the user logged in "Longitude and latitude"
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// Request id for all transaction in the platform.
        /// </summary>
        public string RequestId { get; private set; }
        /// <summary>
        /// User who created the record
        /// </summary>
        public string CreationUser { get; private set; }
        /// <summary>
        /// Record creation date and time
        /// </summary>
        public DateTime? CreationDate { get; private set; }
        /// <summary>
        /// User who updated the record
        /// </summary>
        public string UpdatedUser { get; private set; }
        /// <summary>
        /// Record update date and time
        /// </summary>
        public DateTime? UpdatedDate { get; private set; }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Activates the user
        /// </summary>
        public void Activate()
        {
            this.IsActive = true;
        }

        /// <summary>
        /// Deactivates the user
        /// </summary>
        public void Deactivate()
        {
            this.IsActive = false;
        }

        #endregion

        #region IEntity Members

        /// <summary>
        /// Sets the unique identifier
        /// </summary>
        /// <param name="id">The unique identifier</param>
        void IEntity.SetId(long id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Get the parameters to the insert sql statement
        /// </summary>
        /// <param name="applicationContext"></param>
        /// <returns>Parameters</returns>
        object IEntity.GetInsertParameters(IApplicationContext applicationContext)
        {
            RequestId = applicationContext.RequestId;
            CreationUser = applicationContext.LoggedUser.User;
            CreationDate = DateTime.Now;

            return new
            {
                IsActive,
                Login,
                Password,
                Role,
                Name,
                ShortName,
                TitleId,
                DepartmentId,
                Email,
                BussinessPhone,
                MobilePhone,
                Location,
                RequestId,
                CreationUser,
                CreationDate
            };
        }

        /// <summary>
        /// Get the parameters to the update sql statement
        /// </summary>
        ///  <param name="applicationContext"></param>
        /// <returns>Parameters</returns>
        object IEntity.GetUpdateParameters(IApplicationContext applicationContext)
        {
            RequestId = applicationContext.RequestId;
            UpdatedUser = applicationContext.LoggedUser.User;
            UpdatedDate = DateTime.Now;

            return new
            {
                Id,
                IsActive,
                Login,
                Role,
                Name,
                ShortName,
                TitleId,
                DepartmentId,
                Email,
                BussinessPhone,
                MobilePhone,
                RequestId,
                UpdatedUser,
                UpdatedDate
            };
        }

        #endregion

        #endregion
    }
}
