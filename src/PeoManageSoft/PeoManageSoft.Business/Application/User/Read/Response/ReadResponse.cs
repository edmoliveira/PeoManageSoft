using PeoManageSoft.Business.Infrastructure;

namespace PeoManageSoft.Business.Application.User.Read.Response
{
    /// <summary>
    /// Response data.
    /// </summary>
    public class ReadResponse
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public UserRole Role { get; set; }
        /// <summary>
        /// Indicates whether the user is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Full username
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Short username
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// The object that describes user's job or position.
        /// </summary>
        public ReadTitleResponse Title { get; set; }
        /// <summary>
        /// The object that describes user's department.
        /// </summary>
        public ReadDepartmentResponse Department { get; set; }
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

        #endregion 
    }
}