using PeoManageSoft.Business.Infrastructure;

namespace PeoManageSoft.Business.Domain.Queries.User.Get.Response
{
    /// <summary>
    /// Response for the get user query.
    /// </summary>
    internal class GetResponse
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
        public GetTitleResponse Title { get; set; }
        /// <summary>
        /// The object that describes user's department.
        /// </summary>
        public GetDepartmentResponse Department { get; set; }
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
        /// <summary>
        /// Request id for all transaction in the platform.
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// User who created the record
        /// </summary>
        public string CreationUser { get; set; }
        /// <summary>
        /// Record creation date and time
        /// </summary>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// User who updated the record
        /// </summary>
        public string UpdatedUser { get; set; }
        /// <summary>
        /// Record update date and time
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        #endregion
    }
}
