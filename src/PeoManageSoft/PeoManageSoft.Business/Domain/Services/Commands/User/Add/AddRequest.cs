using PeoManageSoft.Business.Domain.Services.Commands.User._Models;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Request for the add user command.
    /// </summary>
    internal sealed class AddRequest
    {
        #region Properties

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
        /// User password
        /// </summary>
        public string Password { get; set; }
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
        public long TitleId { get; set; }
        /// <summary>
        /// User department
        /// </summary>
        public long DepartmentId { get; set; }
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
        public GeoLocation Location { get; set; }
        /// <summary>
        /// User Policies
        /// </summary>
        public IEnumerable<UserPolicy> Policies { get; set; }
        /// <summary>
        /// Schema resources
        /// </summary>
        public IEnumerable<SchemaResource> SchemaResources { get; set; }

        #endregion
    }
}
