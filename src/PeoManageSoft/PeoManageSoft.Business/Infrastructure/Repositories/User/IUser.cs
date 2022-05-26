using PeoManageSoft.Business.Infrastructure.Repositories.Department;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// Sets Relationships 
    /// </summary>
    internal interface IUser
    {
        #region Methods

        /// <summary>
        /// Set Title object
        /// </summary>
        /// <param name="title">The object that describes user's job or position.</param>
        void SetTitle(TitleEntity title);

        /// <summary>
        /// Set Department object
        /// </summary>
        /// <param name="department">The object that describes user's department.</param>
        void SetDepartment(DepartmentEntity department);

        #endregion
    }
}
