﻿namespace PeoManageSoft.Business.Application.Role.ReadAllWithPagination
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class ReadAllWithPaginationRequest
    {
        #region Properties

        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Quantity per page
        /// </summary>
        public int QuantityPerPage { get; set; }
        /// <summary>
        /// Fields for sorting
        /// </summary>
        public IEnumerable<RoleEnumerators.Fields> OrderByFields { get; set; }
        /// <summary>
        /// Indicates whether sorting is descending.
        /// </summary>
        public bool OrderByIsDesc { get; set; }

        #endregion
    }
}