﻿using PeoManageSoft.Business.Application.Role._Models;

namespace PeoManageSoft.Business.Application.Role.New
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class NewRequest
    {
        #region Properties

        /// <summary>
        /// Indicates whether the role is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Full rolename
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Resources
        /// </summary>
        public IEnumerable<RoleResource> Resources { get; set; }

        #endregion
    }
}
