﻿using PeoManageSoft.Business.Infrastructure;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Update
{
    /// <summary>
    /// Request for the update user command.
    /// </summary>
    internal sealed class UpdateRequest
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
